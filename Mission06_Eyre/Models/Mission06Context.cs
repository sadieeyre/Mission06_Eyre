using Microsoft.EntityFrameworkCore;

namespace Mission06_Eyre.Models
{
    public class Mission06Context : DbContext
    {
        public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) //Constructor
        {
        }

        public DbSet<Application> Movies { get; set; }
    }
}
