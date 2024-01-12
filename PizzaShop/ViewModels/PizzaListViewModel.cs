using PizzaShop.Models;

namespace PizzaShop.ViewModels
{
    public class PizzaListViewModel
    {
        public List<Pizza> Pizzas { get; set; }
        public string? CurrentCategory { get; set; }

        public PizzaListViewModel(IEnumerable<Pizza> pizzas, string currentCategory)
        {
            Pizzas = pizzas;
            CurrentCategory = currentCategory;
        }
    }
}
