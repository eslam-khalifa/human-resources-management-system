using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }

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

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }
        public string? ImageName { get; set; }
    }
}
