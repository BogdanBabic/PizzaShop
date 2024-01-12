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

        public ViewResult List(int categoryId)
        {
            IEnumerable<Pizza> pizzas;
            string? category = "Sve Pice";

            if (categoryId > 0)
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId).OrderBy(p => p.ID);
                category = _categoryRepository.GetCategoryById(categoryId).Name;
            }
            else
            {
                pizzas = _repository.Pizzas.OrderBy(p => p.ID);
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

        public IActionResult CreatePizza(UserPizzaViewModel model)
        {
            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);
            var pizza = new Pizza()
            {
                Name = model.Name,
                Category = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == "Pizze korisnika"),
                LongDescription = model.Ingredients,
                Price = 1500,
                CreatorId = user!.UserId
            };

            _repository.
            return View();
        }
    }
}