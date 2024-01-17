using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class UserPizzaViewModel
    {
        [Required(ErrorMessage ="Unesite ime pice")]
        [Display(Name = "Ime pice")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string Name {  get; set; }
        
        [Required(ErrorMessage = "Morate izabrati sastojke")]
        [Display(Name = "Sastojci")]
        public string Ingredients { get; set; }

        public string AllowedIngredients { get; set; }
    }
}
