using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name can not be null")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name can not be null")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "User Name can't be null")]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Address can't be null")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password can't be null")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Confirm Password can't be null")]
        public string ConfirmPassword { get; set; } = null!;

        public bool IsAgree { get; set; }
    }
}
