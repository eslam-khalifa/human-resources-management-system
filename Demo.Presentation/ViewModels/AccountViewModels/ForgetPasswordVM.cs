using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModels
{
    public class ForgetPasswordVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; } = null!;
    }
}
