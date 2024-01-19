namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }
        Pizza GetPizzaById(int id);
        void SavePizza(Pizza pizza);
        List<Pizza> GetUserPizzas(int userId);
        void DeletePizza(int pizzaId);
        void UpdatePizza(Pizza pizza);
    }
}
