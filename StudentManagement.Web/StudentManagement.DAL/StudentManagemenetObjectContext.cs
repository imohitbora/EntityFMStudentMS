using StudentManagement.Domain.Entities;
using StudentManagement.Domain.EntityMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
{
    public class StudentManagemenetObjectContext : DbContext, IDbContext
    {

        private static readonly string _connectionString = 
            ConfigurationManager.
    ConnectionStrings["STU_context"].ConnectionString;

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
