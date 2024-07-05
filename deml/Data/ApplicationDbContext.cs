using deml.Models;
using Microsoft.EntityFrameworkCore;

namespace deml.Data
{
    //basic configuration
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, name = "action", DisplayOrder = 1 },
                new Category { CategoryId = 2, name = "action", DisplayOrder = 2 },
                new Category { CategoryId = 3, name = "action", DisplayOrder = 3 }

                );

        }
    }
}
