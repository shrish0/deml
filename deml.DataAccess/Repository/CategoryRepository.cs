using deml.DataAccess.Data;
using deml.DataAccess.Repository.IRepository;
using deml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deml.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void update(Category obj)
        {
            _db.Categories.Update(obj);
        }

        public void save()
        {
            _db.SaveChanges();
        }

           
     }
}
