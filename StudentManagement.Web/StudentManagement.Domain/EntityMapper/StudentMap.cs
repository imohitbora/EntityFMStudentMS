using StudentManagement.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace StudentManagement.Domain.EntityMapper
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("STU_Student");
            HasKey(x => x.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            Property(x => x.LastName).HasMaxLength(20);
           // HasMany(x => x.Address);
        }
    }
}
