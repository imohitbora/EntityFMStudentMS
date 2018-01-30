using StudentManagement.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace StudentManagement.Domain.EntityMapper
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("STU_Address");
            HasKey(x => x.Id);
            Property(x => x.City).IsRequired().HasMaxLength(20);
            Property(x => x.Line1).IsRequired().HasMaxLength(20);
        }
    }
}
