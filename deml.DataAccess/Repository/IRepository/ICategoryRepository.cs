
using deml.Models;

namespace deml.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void update(Category obj);
        void save();
    }
}
