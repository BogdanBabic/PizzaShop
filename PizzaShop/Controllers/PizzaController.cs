using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private IPieRepository _repository;
        public PizzaController(IPieRepository repository)
        {
            _repository = repository;
        }
        public ViewResult List(int? categoryId)
        {
            var allPies = _repository.AllPies;

            if (categoryId > 0)
            {
                allPies = allPies.Where(pie => pie.Category.CategoryID == categoryId).ToList();

                return View(allPies);
            }

            //else if (categoryId < 0 || categoryId > 3)
            //{
            //    return NotFound();
            //}

            else
            {
                return View(_repository.AllPies);
            }
        }

    }
}
