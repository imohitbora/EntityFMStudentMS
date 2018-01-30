using StudentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;

        int SaveChanges();
    }
}
