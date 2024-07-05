
using Microsoft.EntityFrameworkCore;
using deml.Models;

namespace deml.DataAccess.Data
{
    //basic configuration
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, name = "action", DisplayOrder = 1 },
                new Category { CategoryId = 2, name = "horror", DisplayOrder = 2 },
                new Category { CategoryId = 3, name = "comedy", DisplayOrder = 3 }

                );

        }
    }
}
