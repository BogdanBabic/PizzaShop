using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaRepository _repository;
        public PizzaController(IPizzaRepository repository)
        {
            _repository = repository;
        }
        public ViewResult List(int? categoryId)
        {
            var allPies = _repository.Pizzas;

            if (categoryId > 0)
            {
                allPies = allPies.Where(pie => pie.Category.CategoryId == categoryId).ToList();

                return View(allPies);
            }

            //else if (categoryId < 0 || categoryId > 3)
            //{
            //    ViewBag.ErrorMessage = "Doslo je do greske!";
            //    List<Pie> pieList = new List<Pie>();
            //    return View(pieList);
            //}
            else
            {
                return View(_repository.Pizzas);
            }
        }

    }
}
