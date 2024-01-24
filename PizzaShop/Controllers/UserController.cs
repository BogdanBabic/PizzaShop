using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Models;
using PizzaShop.TagHelpers;
using PizzaShop.ViewModels;
using System.Reflection;

namespace PizzaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyf;

        public UserController(IUserRepository userRepository, INotyfService notyf)
        {
            _userRepository = userRepository;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [TypeFilter(typeof(UserExceptionFilter))]
        public IActionResult Profile()
        {
            User user = new User();
            throw new Exception("Test Greska");
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

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

                    _notyf.Success("Uspesno ste se ulogovali!");
                    return View("SignInSuccess");
                }
            }

            _notyf.Error("Neispravni kredencijali");

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
                    _notyf.Success("Registracija uspesna!");
                    return View("Success");
                }
                else
                {
                    _notyf.Error("Korisnicno ime je zauzeto!");
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

                _notyf.Success("Uspesno ste se izlogovali!");
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ChangePassword(UpdateUserViewModel model)
        {
            var user = _userRepository.GetUserById(model.Id);

            if (model.ConfirmPassword == model.NewPassword)
            {
                _userRepository.UpdatePassword(user, model.NewPassword);
                ViewBag.Message = "Uspesno ste promenili sifru!";
            }
            return View("Profile", model);
        }

        public IActionResult ChangeAddress(UpdateUserViewModel model)
        {
            var user = _userRepository.GetUserById(model.Id);
            
            if (model.CurrentPassword.Encrypt() == user.Password)
            {
                _userRepository.UpdateAddress(user, model.NewAddress);
            }
            else
            {
                ModelState.AddModelError("", "Uneta sifra se ne poklapa sa vasom sifrom");
                return View("Profile", model);
            }
            return View("Profile");
        }

        public IActionResult OrderHistory(User user)
        {
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

            var userOrders = _userRepository.GetUsersWithPizzasByUserId(user.UserId);

            return View(userOrders);
        }
    }
}
