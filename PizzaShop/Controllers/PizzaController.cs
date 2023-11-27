using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Runtime.CompilerServices;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public PizzaController(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(int? categoryId)
        {
            IEnumerable<Pizza> pizzas;
            string? category = "Sve Pice";

            if (categoryId > 0)
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.CategoryId == categoryId).OrderBy(p => p.ID).ToList();
                category = _categoryRepository.Categories.Where(c => c.CategoryId == categoryId).Select(category => category.Name).FirstOrDefault();
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
    }
}