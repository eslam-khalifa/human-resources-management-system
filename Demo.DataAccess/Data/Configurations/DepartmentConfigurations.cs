using Demo.DataAccess.Entities.DepartmentModel;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigurations : BaseModelConfigurations<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Description).HasColumnType("varchar(100)");
            builder.Property(d => d.Description).IsRequired();
            builder.HasMany(d => d.Employees)
                   .WithOne(e => e.Department)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasData(new Department
            {
                Id = 90,
                Name = "Finance",
                Code = "FIN",
                Description = "Handles company finances, payroll, and budgets",
                CreatedOn = DateOnly.FromDateTime(DateTime.Now.AddYears(-4))
            },
                new Department
                {
                    Id = 50,
                    Name = "Marketing",
                    Code = "MKT",
                    Description = "Focuses on advertising, branding, and outreach",
                    CreatedOn = DateOnly.FromDateTime(DateTime.Now.AddYears(-3))
                },
                new Department
                {
                    Id = 60,
                    Name = "Sales",
                    Code = "SLS",
                    Description = "Responsible for sales operations and client relationships",
                    CreatedOn = DateOnly.FromDateTime(DateTime.Now.AddYears(-2))
                },
                new Department
                {
                    Id = 70,
                    Code = "RND",
                    Name = "R&D",
                    Description = "Innovates and develops new products and services",
                    CreatedOn = DateOnly.FromDateTime(new DateTime(2019, 9, 18))
                },
                new Department
                {
                    Id = 80,
                    Name = "Support",
                    Code = "SUP",
                    Description = "Provides technical and customer support",
                    CreatedOn = DateOnly.FromDateTime(DateTime.Now.AddYears(-1))
                });
            base.Configure(builder);
        }
    }
}
