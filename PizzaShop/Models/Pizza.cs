namespace PizzaShop.Models
{
    public class Pizza
    {
        public int ID { get; set; }
        private string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPizzaOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public Category Category { get; set; }

    }
}
