using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.EmployeeViewModels
{
    public class EmployeeVM
    {
        [MaxLength(50, ErrorMessage = "Max Length should be 50")]
        [MinLength(5, ErrorMessage = "Min Length should be 5")]
        public string Name { get; set; } = string.Empty;

        [Range(20, 50)]
        public int Age { get; set; }

        [RegularExpression(@"^\d+-[A-Za-z]+-[A-Za-z]+-[A-Za-z]+$", ErrorMessage = "The adderss you entered is invalid! (Format: 123-City-Street-Country)")]
        public string? Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Display(Name = "Last Modified By")]
        public int LastModifiedBy { get; set; }

        [Display(Name = "Department Name")]
        public int? DepartmentId { get; set; }
        public bool IsEditMode { get; set; } = false;
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
