using Microsoft.EntityFrameworkCore;

namespace Soteria.Data
{
    public class SoteriaContext : DbContext
    {
        public SoteriaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginHistory> LoginHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginHistory>()
                .HasIndex(p => new { p.Username });

            modelBuilder.Entity<LoginHistory>()
                .HasIndex(p => new { p.DateTime });
        }
    }
}
