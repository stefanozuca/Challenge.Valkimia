using Challenge.Valkimia.Infrastructure.Resources;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Valkimia.Presentation.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ResourceKeys.Validations_Required)]
        [Display(Name = ResourceKeys.Labels_Email)]
        public string Email { get; set; }
        [Required(ErrorMessage = ResourceKeys.Validations_Required)]
        [Display(Name = ResourceKeys.Labels_Password)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
