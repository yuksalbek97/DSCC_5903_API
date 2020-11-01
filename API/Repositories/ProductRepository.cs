using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.Find(id); 
            _dbContext.Products.Remove(product); 
            
            _dbContext.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return _dbContext.Products.Include(s => s.Category).AsQueryable();
        }

        public Product GetById(int id)
        {
            var prod = _dbContext.Products.Find(id); 
            _dbContext.Entry(prod).Reference(s => s.Category).Load();
            return prod;        
        }

        public void Update(Product entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
