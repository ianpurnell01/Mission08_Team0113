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

    }
}
