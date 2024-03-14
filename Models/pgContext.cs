using Microsoft.EntityFrameworkCore;

namespace cloudblues_api.Models
{
    public class pgContext : DbContext
    {
        public pgContext(DbContextOptions<pgContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=root");
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
    }
}
