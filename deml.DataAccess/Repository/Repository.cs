using deml.DataAccess.Data;
using deml.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace deml.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
        public void Add(T obj)
        {
           dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            _db.Remove(obj);
        }

        public void DeleteAll(IEnumerable<T> obj)
        {
            _db.RemoveRange(obj);
        }

      
    }
}
