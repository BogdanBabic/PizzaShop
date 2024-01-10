using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Trenutna sifra")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Unesite novu sifru")]
        [Display(Name = "Nova sifra")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Morate da potvrdite novu sifru")]
        [Display(Name = "Potvrdi novu sifru")]
        [Compare("NewPassword", ErrorMessage = "Uneta sifra se ne poklapa!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Morate unetu novu adresu")]
        [Display(Name = "Nova adresa")]
        public string NewAddress { get; set; }
    }
}