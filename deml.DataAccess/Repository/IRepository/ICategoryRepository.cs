﻿
using deml.Models;

namespace deml.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
