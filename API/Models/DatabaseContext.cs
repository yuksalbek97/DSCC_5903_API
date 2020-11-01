
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<API.Models.Category> Category { get; set; }
    }
}