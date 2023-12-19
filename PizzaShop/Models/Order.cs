using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }


        public List<OrderDetail> OrderDetails { get; set; } = default;

        [Required(ErrorMessage = "Ime je neispravno")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
