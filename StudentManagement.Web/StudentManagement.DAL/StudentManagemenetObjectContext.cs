using StudentManagement.Domain.Entities;
using StudentManagement.Domain.EntityMapper;
using System.Configuration;
using System.Data.Entity;

namespace StudentManagement.DAL
{
    public class StudentManagemenetObjectContext : DbContext, IDbContext
    {

        private static readonly string _connectionString =
            ConfigurationManager.
    ConnectionStrings["STU_context"].ConnectionString;

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Departments { get; set; }


        public StudentManagemenetObjectContext()
            : base(_connectionString)
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
