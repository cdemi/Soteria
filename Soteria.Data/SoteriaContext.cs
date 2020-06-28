using Microsoft.EntityFrameworkCore;

namespace Soteria.Data
{
    public class SoteriaContext : DbContext
    {
        public SoteriaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginHistory> LoginHistories { get; set; }
    }
}
