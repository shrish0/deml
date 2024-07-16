using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace deml.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T,bool>> filter);
        public void Add(T obj);
       
        public void Delete(T obj);
        public void DeleteAll(IEnumerable<T> obj);
    }
}
