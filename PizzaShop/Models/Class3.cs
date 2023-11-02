namespace PizzaShop.Models
{
    public class CategoryRepository : IcategoryRepository
    {
        public IEnumerable<Category> Categories { get;}
        
        public Category GetCategoryById(int categoryId)
        {
            foreach (var category in Categories)
            {
                if (category.CategoryID == categoryId)
                {
                    return category;
                }
            }
            return null;
        }
            
        
    }
}
