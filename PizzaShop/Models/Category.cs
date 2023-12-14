using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class Category
    {
        public int CategoryId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Pizza> Pizzas { get; set; }

    }
}
