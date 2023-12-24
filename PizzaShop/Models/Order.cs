using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }


        public List<OrderDetail>? OrderDetails { get; set; } = default;

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je neispravno")]
        [StringLength(20, ErrorMessage = "Ime je predugacko")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Prezime je neispravno")]
        [StringLength(20, ErrorMessage = "Prezime je predugacko")]
        public string LastName { get; set; }

        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Adresa je neispravna")]
        [StringLength(50, ErrorMessage = "Adresa je predugacka")]
        public string Address { get; set; }
        public string? City { get; set; }
        [Display(Name = "Drzava")]
        [Required(ErrorMessage = "Drzava je obavezna")]
        [StringLength(50, ErrorMessage = "Naziv drzave je predugacak")]
        public string Country { get; set; }

        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^(\+\d{15})$", ErrorMessage = "Broj telefona je neispravan")]
        [Required(ErrorMessage ="Broj telefona je obavezan!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adresa")]
        [StringLength(50, ErrorMessage = "Email adresa je predugacka")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }

        [BindNever]
        public decimal OrderTotal { get; set; }
    }
}
