using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Runtime.CompilerServices;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public PizzaController(IPizzaRepository repository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public ViewResult List(int? categoryId)
        {
            IEnumerable<Pizza> pizzas;
            string category = "Sve pizze";

            var categoryObj = _categoryRepository.GetCategoryById(categoryId);

            if (categoryObj != null)
            {
                category = "Sve pizze";
            }

            if (category == "Sve pizze")
            {
                pizzas = _repository.Pizzas.OrderBy(p => p.ID).Where(c => c.CreatorId == null);
            }

            if (categoryId > 0)
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId).OrderBy(p => p.ID);
            }
 
            if (category == "Pice Korisnika")
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId && p.CreatorId ==  ).OrderBy(p => p.ID)
                return View("UserPizzas", new PizzaListViewModel(pizzas, category));
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
            return View(vm);
        }

        public IActionResult SavePizza(UserPizzaViewModel model)
        {
            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);
         
            var pizza = new Pizza()
            {
                Name = model.Name,
                Category = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == "Pizze korisnika"),
                LongDescription = model.Ingredients,
                Price = 1500,
                CreatorId = user!.UserId,
                ShortDescription = model.Ingredients,
                ImageThumbnailUrl = string.Empty,
                ImageUrl = string.Empty,
                IsPizzaOfTheWeek = false
            };

            _repository.SavePizza(pizza);
            return RedirectToAction("Profile", "User");
        }
    }
}