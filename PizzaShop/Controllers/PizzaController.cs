using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyf;

        public PizzaController(IPizzaRepository repository, ICategoryRepository categoryRepository, IUserRepository userRepository, INotyfService notyf)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _notyf = notyf;
        }

        public ViewResult List(int? categoryId)
        {
            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            IEnumerable<Pizza> pizzas;
            string? category = "Sve pice";

            var categoryObj = _categoryRepository.GetCategoryById(categoryId);

            if (categoryObj != null)
            {
                category = categoryObj.Name;
            }

            if (category == "Sve pice")
            {
                pizzas = _repository.Pizzas.OrderBy(p => p.ID).Where(c => c.CreatorId == null);
            }

            if (category == "Pice Korisnika")
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId && p.CreatorId == user.UserId).OrderBy(p => p.ID);
                return View("UserPizzas", new PizzaListViewModel(pizzas, category));
            }

            else
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId).OrderBy(p => p.ID);
            }

            return View(new PizzaListViewModel(pizzas, category));
        }

    public ViewResult Details(int id)
        {
            Pizza p = _repository.GetPizzaById(id);

            return View(p);
        }

        public IActionResult Index()
        {
            ViewBag.Uslov = false;
            ViewBag.Message = "Ovo je server-side poruka.";
            ViewBag.Message2 = "Ovo je druga poruka";
            return View();
        }
        public IActionResult PizzaBuilder()
        {
            var vm = new UserPizzaViewModel();
            vm.AllowedIngredients = "Paradajz sos, Mocarela, Pecurke, Sunka, Masline, Bosiljak, Kobasica, Pavlaka, Paprika, Parmezan";

            return View(vm);
        }

        public IActionResult SavePizza(UserPizzaViewModel model)
        {
            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            var allowedIngredients = model.AllowedIngredients.Split(',').Select(s => s.Trim()).Select(s => s.ToLower()).ToList();
            var ingredients = model.Ingredients.Split(',').Select(s => s.Trim()).Select(s => s.ToLower()).ToList();

            var disallowedWords = ingredients.Where(word => !allowedIngredients.Contains(word)).ToList();

            if (disallowedWords.Any())
            {
                ModelState.AddModelError("", "Uneti sastojak ne postoji: " + string.Join(", ", disallowedWords));
                return View("PizzaBuilder", model);
            }

            var pizza = new Pizza()
            {
                Name = model.Name,
                Category = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == "Pice Korisnika"),
                LongDescription = model.Ingredients,
                Price = 1500,
                CreatorId = user!.UserId,
                ShortDescription = model.Ingredients,
                ImageThumbnailUrl = string.Empty,
                ImageUrl = string.Empty,
                IsPizzaOfTheWeek = false
            };

            _repository.SavePizza(pizza);

            _notyf.Success("Uspesno ste kreirali svoju picu!");

            return RedirectToAction("Profile", "User");
        }

        public IActionResult PizzaManager()
        {
            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            var vm = _repository.GetUserPizzas(user!.UserId);
            return View(vm);
        }

        public IActionResult RemoveUserPizza(int pizzaId)
        {

            _repository.DeletePizza(pizzaId);

            _notyf.Success("Pica obrisana!");

            return RedirectToAction("Profile", "User");
        }

        public IActionResult PizzaEditor(int pizzaId)
        {
            var pizza = _repository.GetPizzaById(pizzaId);

            PizzaManagerViewModel vm = new PizzaManagerViewModel()
            {
                Name = pizza.Name,
                ID = pizza.ID
            };
            vm.AllowedIngredients = "Paradajz sos, Mocarela, Pecurke, Sunka, Masline, Bosiljak, Kobasica, Pavlaka, Paprika, Parmezan";
            return View(vm);
        }

        public IActionResult EditPizza(PizzaManagerViewModel model)
        {
            var allowedIngredients = model.AllowedIngredients.Split(',').Select(s => s.Trim()).Select(s => s.ToLower()).ToList();
            var ingredients = model.Ingredients.Split(',').Select(s => s.Trim()).Select(s => s.ToLower()).ToList();

            var disallowedWords = ingredients.Where(word => !allowedIngredients.Contains(word)).ToList();

            if (disallowedWords.Any())
            {
                ModelState.AddModelError("", "Uneti sastojak ne postoji: " + string.Join(", ", disallowedWords));
                return View("PizzaBuilder", model);
            }

            var pizza = _repository.GetPizzaById(model.ID);

            pizza.Name = model.Name;
            pizza.LongDescription = string.Join(", ", ingredients);

            _repository.UpdatePizza(pizza);

            _notyf.Success("Izmene napravljene");
            return RedirectToAction("Profile", "User");
        }
    }
}