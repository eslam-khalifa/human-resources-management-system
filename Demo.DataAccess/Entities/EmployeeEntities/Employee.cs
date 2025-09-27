using Demo.DataAccess.Entities.DepartmentModel;
using Demo.DataAccess.Entities.Shared;
using Demo.DataAccess.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Entities.EmployeEntities
{
    public class Employee : BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Max Length should be 50")]
        [MinLength(5, ErrorMessage = "Min Length should be 5")]
        public string Name { get; set; } = string.Empty;

        [Range(20, 50)]
        public int Age { get; set; }

        [RegularExpression(@"^\d+-[A-Za-z]+-[A-Za-z]+-[A-Za-z]+$", ErrorMessage = "The adderss you entered is invalid! (Format: 123-City-Street-Country)")]
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }

        [RegularExpression(@"^[A-Za-z0-9.\-_]+@[A-Za-z0-9-]+\.[A-Za-z]{2,}(\.[A-Za-z]{2,})*$", ErrorMessage = "The email you entered is invalid! (Format: john@gmail.com)")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public string? ImageName { get; set; }
    }
}
