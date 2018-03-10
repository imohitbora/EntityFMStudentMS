using StudentManagement.Domain.Entities;
using System.Linq;

namespace StudentManagement.DAL.IEFManager
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);

        void Delete(T entity);

        void Insert(T entity);

        void Update(T entity);

        IQueryable<T> Table { get; }
    }
}
