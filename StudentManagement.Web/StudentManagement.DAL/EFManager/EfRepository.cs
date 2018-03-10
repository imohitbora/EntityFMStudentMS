using StudentManagement.DAL.IEFManager;
using StudentManagement.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace StudentManagement.DAL.EFManger
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IDbContext _context;
        private IDbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        public IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }


        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                return;
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                return;
            }

            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                return;
            }
            
            _context.SaveChanges();
        }
    }
}
