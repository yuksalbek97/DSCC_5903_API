using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category GetById(int id);
        void Create(Category entity);
        void Update(Category entity);
        void Delete(int id);
    }
}
