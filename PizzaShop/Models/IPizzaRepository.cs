namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {
        Pizza GetPizzaById(int id);

        IEnumerable<Pizza> Pizzas { get; }
    }
}
