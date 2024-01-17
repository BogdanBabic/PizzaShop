using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace PizzaShop.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public PizzaRepository(ApplicationDbContext applicationDbConext)
        {
            _applicationDbContext = applicationDbConext;
        }

        public Pizza GetPizzaById(int id)
        {
            return _applicationDbContext.Pizzas.Include(p => p.Category).FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Pizza> Pizzas
        {
            get
            {
                return _applicationDbContext.Pizzas.Include(p => p.Category);
            }
        }

        public void SavePizza(Pizza pizza)
        {
            _applicationDbContext.Pizzas.Add(pizza);
            _applicationDbContext.SaveChanges();
        }

        public List<Pizza> GetUserPizzas(int userId)
        {
            return _applicationDbContext.Pizzas.Where(p => p.CreatorId == userId).ToList();
        }
    }
}
