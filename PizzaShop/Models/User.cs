using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Korisnicko ime")]
        [Required(ErrorMessage = "Korisnicko ime je neispravno")]
        [StringLength(20, ErrorMessage = "Korisnicko ime je predugacko")]
        public string Username { get; set; }

        [Display(Name = "Sifra")]
        [Required(ErrorMessage = "Sifra je obavezna")]
        [StringLength(20, ErrorMessage = "Sifra ne sme imati vise od 20 karaktera")]
        public string Password { get; set; }

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

        [Display(Name = "Grad")]
        [Required(ErrorMessage = "Grad je obavezan")]
        [StringLength(50, ErrorMessage = "Naziv grada je predugacak")]
        public string City { get; set; }

        [Display(Name = "Drzava")]
        [Required(ErrorMessage = "Drzava je obavezna")]
        [StringLength(50, ErrorMessage = "Naziv drzave je predugacak")]
        public string Country { get; set; }

        [Display(Name = "Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        [StringLength(50, ErrorMessage = "Email adresa je predugacka")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^\+?[\d ()-]{1,15}$", ErrorMessage = "Broj telefona je neispravan")]
        [Required(ErrorMessage = "Broj telefona je obavezan!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}
