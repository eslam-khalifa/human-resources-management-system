using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModels
{
    public class ResetPasswordVM
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
