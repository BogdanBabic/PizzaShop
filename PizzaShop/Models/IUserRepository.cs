namespace PizzaShop.Models
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        bool IsExisting(string username);
        bool IsPasswordOk(string password);
    }
}
