using StudentManagement.Domain.Entities;
using System.Data.Entity;

namespace StudentManagement.DAL
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;

        int SaveChanges();
    }
}
