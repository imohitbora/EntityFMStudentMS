using StudentManagement.Domain.Entities;
using StudentManagement.Domain.EntityMapper;
using System.Configuration;
using System.Data.Entity;

namespace StudentManagement.DAL
{
    public class StudentManagemenetObjectContext : DbContext, IDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Departments { get; set; }


        public StudentManagemenetObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
    }
}
