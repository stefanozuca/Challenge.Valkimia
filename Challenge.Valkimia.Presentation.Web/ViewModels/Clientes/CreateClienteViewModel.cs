using Challenge.Valkimia.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Valkimia.Presentation.Web.ViewModels
{
    public class CreateClienteViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "Supera el maximo de 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Contraseña")]
        [MinLength(10, ErrorMessage = "Debe poseer al menos 10 caracteres")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Supera el maximo de 100 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Comapo obligatorio")]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "Supera el maximo de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Comapo obligatorio")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "No tiene formato de Email")]
        [MaxLength(100, ErrorMessage = "Supera el maximo de 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Domicilio")]
        [MaxLength(50, ErrorMessage = "Supera el maximo de 50 caracteres")]
        public string Domicilio { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string CiudadID { get; set; }

        [Display(Name = "Habilitado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public bool Habilitado { get; set; }



    }
}
