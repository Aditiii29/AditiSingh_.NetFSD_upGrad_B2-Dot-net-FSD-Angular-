using CategoryService.API.Model;
using CategoryService.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.API.Data
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}