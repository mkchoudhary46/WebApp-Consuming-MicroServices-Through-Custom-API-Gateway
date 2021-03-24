using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore.Relational;
namespace Assignment.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.ToTable("Employee");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Contact).IsRequired();
            entityBuilder.Property(t => t.GenderId).IsRequired();
            entityBuilder.Property(t => t.DepartmentId).IsRequired();
            entityBuilder.Property(t => t.Salary).IsRequired();
            entityBuilder.Property(t => t.PasswordSalt);
            entityBuilder.Property(t => t.PasswordHash);
            entityBuilder.HasOne(e => e.Gender).WithMany(e => e.Employees).HasForeignKey(e => e.GenderId);
            entityBuilder.HasOne(e => e.Department).WithMany(e => e.Employees).HasForeignKey(e => e.DepartmentId);

        }
    }
}
