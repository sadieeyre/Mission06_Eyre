using Microsoft.EntityFrameworkCore;

namespace Mission06_Eyre.Models
{
    public class Mission06Context : DbContext
    {
        public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) //Constructor
        {
        }
        //Create Movies and categories 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//Upload pre-filled out entities from database in 
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 2, CategoryName = "Drama" },
                new Category { CategoryID = 3, CategoryName = "Television" },
                new Category { CategoryID = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 5, CategoryName = "Comedy" },
                new Category { CategoryID = 6, CategoryName = "Family" },
                new Category { CategoryID = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );
        }

    }
}
