namespace PizzaShop.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
    }
}
