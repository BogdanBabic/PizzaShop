//namespace PizzaShop.Models
//{
//    public class CategoryRepository : IcategoryRepository
//    {
//        public IEnumerable<Category> Categories { get; }

//        public Category GetCategoryById(int categoryId)
//        {
//            foreach (var category in Categories)
//            {
//                if (category.CategoryID == categoryId)
//                {
//                    return category;
//                }
//            }
//            return null;
//        }
//        private List<Category> allCategories = new List<Category>();

//        public CategoryRepository()
//        {
//            Category category1 = new Category(1, "Pice sa mesom", "Description");
//            Category category2 = new Category(2, "Veganske pice", "Description");
//            Category category3 = new Category(3, "Pice bez glutena", "Description");

//            allCategories.Add(category1);
//            allCategories.Add(category2);
//            allCategories.Add(category3);
//        }
//    }
//}
