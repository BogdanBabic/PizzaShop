using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Diagnostics;

namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly INotyfService _notyf;
        public HomeController(IPizzaRepository pizzaRepository, INotyfService notyf)
        {
            _pizzaRepository = pizzaRepository;
            _notyf = notyf;
        }

        public IActionResult Index() 
        {
            var pizzasOfTheWeek = _pizzaRepository.Pizzas.Where(p => p.IsPizzaOfTheWeek == true).ToList();
            return View(new HomeViewModel(pizzasOfTheWeek));
        }

        public IActionResult Pretplata()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAction(int? id)
        {
            if (id == 1)
            {
                throw new Exception("File Not Found");
            }

            else if ( id == 2)
            {
                return StatusCode(500);
            }

            return View();
        }
    }
}