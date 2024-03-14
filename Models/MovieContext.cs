using Microsoft.EntityFrameworkCore;

namespace cloudblues_api.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=root");
    public DbSet<Movie> Movies { get; set; } = null!;
    }
}
