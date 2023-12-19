using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Pizza Pizza { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
