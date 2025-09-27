using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length should be 50")]
        [MinLength(5, ErrorMessage = "Min Length should be 5")]
        public string Name { get; set; } = string.Empty;

        [Range(20, 50)]
        public int Age { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [EmailAddress]
        [DisplayName("Email Address")]
        public string? Email { get; set; }
        public string Gender { get; set; }

        [DisplayName("Employee Type")]
        public string EmployeeType { get; set; }
        public string? Department { get; set; }
    }
}
