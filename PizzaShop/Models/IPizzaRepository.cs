namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }
        Pizza GetPizzaById(int id);
        void SavePizza(Pizza pizza);
    }
}
