using PizzaShop.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class PizzaManagerViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Ime pice je obavezno!")]
        [Display(Name = "Novo ime pice")]
        [StringLength(20, ErrorMessage = "Ime je predugacko")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Morate izabrati sastojke")]
        [Display(Name = "Novi sastojci")]
        public string Ingredients { get; set; }

        public string AllowedIngredients { get; set; }
    }
}
