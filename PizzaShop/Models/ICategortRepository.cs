namespace PizzaShop.Models
{
    public interface IcategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        Category GetCategoryByID(int id);
    }
}
