using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0113.Models
{
    public class Mission8Context : DbContext
    {
        public Mission8Context(DbContextOptions<Mission8Context> options) : base (options)
        {
        } //Constructor

        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }

            );
        }

    }
}
