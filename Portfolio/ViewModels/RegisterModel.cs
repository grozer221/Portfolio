using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Now wrote login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Now wrote password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
