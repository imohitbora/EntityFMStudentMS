using StudentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
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
