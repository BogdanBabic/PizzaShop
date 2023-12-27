using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;

namespace PizzaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public UserController(IUserRepository userRepository, ApplicationDbContext context)
        {
            _userRepository = userRepository;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult SignIn(LoginViewModel loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginUser);
            }

            var user = _userRepository.GetUserByUsername(loginUser.Username);

            ModelState.AddModelError("", "Neispravni podaci");

            return View("Login", loginUser);
        }

        public IActionResult SignInSuccess()
        {
            return View();
        }
        public IActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                var isExisting = _userRepository.IsExisting(registerUser.Username);

                if (isExisting)
                {
                    ModelState.AddModelError("", "Korisnicko ime " + registerUser.Username + " vec postoji");

                    return View("Index", registerUser);
                }
                else
                {
                    _userRepository.CreateUser(registerUser);

                    return View("Success");
                }
            }
            else
            {
                return View("Index", registerUser);
            }
        }
    }
}
