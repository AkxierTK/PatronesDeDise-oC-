using System.ComponentModel.DataAnnotations;

namespace PatronesDeDiseñoASP.Models.ViewModels
{
    public class FormBeerViewModel
    {
        //Required lo hace obligatorio
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Estilo")]
        public string Style { get; set; }
        //si pones ? es que puede venir null
        public Guid? BrandId { get; set; }
        [Display(Name="Otra marca")]
        public string OtherBrand { get; set; }


    }
}
