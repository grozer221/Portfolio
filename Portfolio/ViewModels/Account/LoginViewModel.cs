using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Not wrote login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Not wrote password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
