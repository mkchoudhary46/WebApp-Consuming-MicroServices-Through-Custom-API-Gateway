using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Data.Mappings
{
    public class DepartmentMap :  IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entityBuilder)
        {
            entityBuilder.ToTable("Department");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
