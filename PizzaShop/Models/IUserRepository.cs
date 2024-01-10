using PizzaShop.ViewModels;

namespace PizzaShop.Models
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUserByUsername(string username);
        User GetUserById(int id);
        public User GetUsersWithPizzasByUserId(int userId);
        public void UpdatePassword(User user, string password);
        public void UpdateAddress(User user, string newAddress);
    }
}
