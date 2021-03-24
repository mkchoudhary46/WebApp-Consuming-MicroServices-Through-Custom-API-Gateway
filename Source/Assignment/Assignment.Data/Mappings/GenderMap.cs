using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Data.Mappings
{
    public class GenderMap :   IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> entityBuilder)
        {
            entityBuilder.ToTable("Gender");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
