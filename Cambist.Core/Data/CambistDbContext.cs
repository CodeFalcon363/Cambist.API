using Cambist.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cambist.Core.Data
{
    public class CambistDbContext : DbContext
    {
        public CambistDbContext(DbContextOptions<CambistDbContext> options) : base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ConversionRecord> ConversionRecords { get; set; }
        public DbSet<WatchlistItem> WatchlistItems { get; set; }

    }

}
