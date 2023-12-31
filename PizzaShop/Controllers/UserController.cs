using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Text.Json.Serialization;

namespace PizzaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Profile()
        {
            User user = new User();
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

            var dbUser = _userRepository.GetUserById(user.UserId);

            var vm = new UpdateUserViewModel()
            {
                Id = user.UserId,
                Username = user.Username
            };

            return View(vm);
        }
        public IActionResult SignIn(LoginViewModel loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginUser);
            }

            var user = _userRepository.GetUserByUsername(loginUser.Username);

            if (user != null)
            {
                var isPasswordOk = EncryptionHelper.Encrypt(loginUser.Password) == user.Password ? true : false;

                if (isPasswordOk)
                {
                    user.Password = "";
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(1);
                    var serializedUser = JsonConvert.SerializeObject(user);
                    Response.Cookies.Append("User", serializedUser, cookieOptions);

                    return View("SignInSuccess");
                }
            }

            ModelState.AddModelError("", "Neispravni kredencijali");

            return View("Login", loginUser);
        }

        public IActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserByUsername(registerUser.Username);

                if (user == null)
                {
                    _userRepository.CreateUser(registerUser);
                    return View("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Korisnicko ime " + registerUser.Username + " je zauzeto");
                    return View("Index", registerUser);
                }
            }
            else
            {
                return View("Index", registerUser);
            }
        }

        public IActionResult Logout()
        {
            if (Request.Cookies["User"] != null)
            {
                Response.Cookies.Delete("User");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
