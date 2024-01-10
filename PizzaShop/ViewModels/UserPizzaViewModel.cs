using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class UserPizzaViewModel
    {
        [Required(ErrorMessage ="Morati dodeliti ime vasoj pizzi")]
        [Display(Name = "Name")]
        public string Name {  get; set; }
        public string Ingredients { get; set; }

        [Display(Name = "Paradajz sos")]
        public bool ImaParadajzSos { get; set; }

        [Display(Name = "Mocarella")]
        public bool ImaMocarellu { get; set; }

        [Display(Name = "Pecurke")]
        public bool ImaPecurke { get; set; }

        [Display(Name = "Sunka")]
        public bool ImaSunku { get; set; }

        [Display(Name = "Crne masline")]
        public bool ImaCrneMasline { get; set; }

        [Display(Name = "Bosiljak")]
        public bool ImaBosiljak { get; set; }

        [Display(Name = "Crveni luk")]
        public bool ImaCrveniLuk { get; set; }

        [Display(Name = "Pavlaka")]
        public bool ImaPavlaku { get; set; }

        [Display(Name = "Paprika")]
        public bool ImaPapriku { get; set; }

        [Display(Name = "Parmezan")]
        public bool ImaParmezan { get; set; }
    }
}
