using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    internal class EmployeeConfigurations : BaseModelConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable<Employee>("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).IsRequired(false).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).IsRequired(true).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Gender).HasConversion(empGender => empGender.ToString(), _gender => Enum.Parse<Gender>(_gender));
            builder.Property(e => e.EmployeeType).HasConversion(employeeType => employeeType.ToString(), _employeeType => Enum.Parse<EmployeeType>(_employeeType));
            builder.HasData(
                new Employee { Id = 1004, Name = "Alice Johnson", Age = 28, Address = "101-Cairo-Maadi-Egypt", IsActive = true, Salary = 12000, Email = "alice.johnson@example.com", PhoneNumber = "01012345678", HiringDate = DateTime.Now.AddYears(-2), Gender = Gender.Female, EmployeeType = EmployeeType.FullTime, DepartmentId = 10 },
                new Employee { Id = 1005, Name = "Omar Khaled", Age = 32, Address = "202-Giza-Dokki-Egypt", IsActive = true, Salary = 15000, Email = "omar.khaled@example.com", PhoneNumber = "01098765432", HiringDate = DateTime.Now.AddYears(-3), Gender = Gender.Male, EmployeeType = EmployeeType.PartTime, DepartmentId = 20 },
                new Employee { Id = 1006, Name = "Mona Adel", Age = 26, Address = "303-Alexandria-SidiBishr-Egypt", IsActive = false, Salary = 10000, Email = "mona.adel@example.com", PhoneNumber = "01122334455", HiringDate = DateTime.Now.AddYears(-1), Gender = Gender.Female, EmployeeType = EmployeeType.Intern, DepartmentId = 40 },
                new Employee { Id = 1007, Name = "Ahmed Samir", Age = 40, Address = "404-Cairo-NasrCity-Egypt", IsActive = true, Salary = 20000, Email = "ahmed.samir@example.com", PhoneNumber = "01234567890", HiringDate = DateTime.Now.AddYears(-10), Gender = Gender.Male, EmployeeType = EmployeeType.FullTime, DepartmentId = 50 },
                new Employee { Id = 1008, Name = "Sara Nabil", Age = 24, Address = "505-Cairo-Heliopolis-Egypt", IsActive = true, Salary = 9000, Email = "sara.nabil@example.com", PhoneNumber = "01566778899", HiringDate = DateTime.Now.AddMonths(-8), Gender = Gender.Female, EmployeeType = EmployeeType.Contract, DepartmentId = 60 },
                new Employee { Id = 1009, Name = "Youssef Hany", Age = 35, Address = "606-Giza-Haram-Egypt", IsActive = true, Salary = 17000, Email = "youssef.hany@example.com", PhoneNumber = "01055667788", HiringDate = DateTime.Now.AddYears(-5), Gender = Gender.Male, EmployeeType = EmployeeType.FullTime, DepartmentId = 70 },
                new Employee { Id = 1010, Name = "Laila Hassan", Age = 29, Address = "707-Cairo-Zamalek-Egypt", IsActive = false, Salary = 11000, Email = "laila.hassan@example.com", PhoneNumber = "01299887766", HiringDate = DateTime.Now.AddYears(-4), Gender = Gender.Female, EmployeeType = EmployeeType.PartTime, DepartmentId = 80 },
                new Employee { Id = 1011, Name = "Khaled Mostafa", Age = 45, Address = "808-Cairo-Downtown-Egypt", IsActive = true, Salary = 25000, Email = "khaled.mostafa@example.com", PhoneNumber = "01044556677", HiringDate = DateTime.Now.AddYears(-15), Gender = Gender.Male, EmployeeType = EmployeeType.FullTime, DepartmentId = 90 },
                new Employee { Id = 1012, Name = "Nour Ahmed", Age = 22, Address = "909-Alexandria-Montaza-Egypt", IsActive = true, Salary = 8000, Email = "nour.ahmed@example.com", PhoneNumber = "01533445566", HiringDate = DateTime.Now.AddMonths(-6), Gender = Gender.Female, EmployeeType = EmployeeType.Intern, DepartmentId = 10 },
                new Employee { Id = 1013, Name = "Hussein Ali", Age = 38, Address = "1001-Cairo-Mokattam-Egypt", IsActive = true, Salary = 18000, Email = "hussein.ali@example.com", PhoneNumber = "01155667788", HiringDate = DateTime.Now.AddYears(-7), Gender = Gender.Male, EmployeeType = EmployeeType.Contract, DepartmentId = 20 }
            );
            base.Configure(builder);
        }
    }
}
