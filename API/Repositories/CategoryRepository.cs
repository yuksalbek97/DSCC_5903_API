using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _dbContext;

        public CategoryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Category entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _dbContext.Category.Find(id);
            _dbContext.Category.Remove(category);

            _dbContext.SaveChanges();
        }

        public IQueryable<Category> GetAll()
        {
            return _dbContext.Category.AsQueryable() ;
        }

        public Category GetById(int id)
        {
            var category = _dbContext.Category.Find(id);
            return category;
        }

        public void Update(Category entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
