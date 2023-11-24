﻿using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using System.Runtime.CompilerServices;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaRepository _repository;

        public PizzaController(IPizzaRepository repository)
        {
            _repository = repository;
        }
        public ViewResult List(int? categoryId, int pageSize)

        {
            var allPies = _repository.Pizzas;

            if (categoryId > 0)
            {
                allPies = allPies.Where(p => p.Category.CategoryId == categoryId).ToList();

                return View(allPies.Take(pageSize));
            }
            else
            {
                return View(allPies.Take(pageSize));
            }
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