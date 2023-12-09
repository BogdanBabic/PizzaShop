namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }

        Pizza GetPizzaById(int id);
    }
}
