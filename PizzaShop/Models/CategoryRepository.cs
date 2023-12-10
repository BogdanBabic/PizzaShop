using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;

namespace PizzaShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories { get; }
        private List<Category> _categories = new List<Category>();


        public CategoryRepository()
        {
           
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }


        public Category GetCategoryById(int categoryId)
        {
            foreach (var category in Categories)
            {
                if (category.CategoryId == categoryId)
                {
                    return category;
                }

            }

            return null;
        }
    }
}