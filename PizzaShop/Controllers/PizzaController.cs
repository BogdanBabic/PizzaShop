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
        public ViewResult List()
        {
            return View(_repository.AllPies);
        }
        public IActionResult Index()
        {
            ViewBag.Message = "Ovo je server-side poruka";
            ViewBag.Message2 = "Još jedna server-side poruka";
            ViewBag.Uslov = true;
            return View();
        }
    }
}
