using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.Infraestructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(b => new
            {
                b.Id
            });
            base.OnModelCreating(modelBuilder);

        }
    }
}
