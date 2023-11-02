namespace PizzaShop.Models
{
    public class Pie
    {
        public int PieID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price {  get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
    }
}
