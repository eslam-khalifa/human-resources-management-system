using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared;

namespace Demo.DataAccess.Entities.DepartmentModel
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
