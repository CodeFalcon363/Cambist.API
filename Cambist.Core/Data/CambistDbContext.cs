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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConversionRecord>()
                .Property(p => p.Rate)
                .HasPrecision(18, 8);

            modelBuilder.Entity<ConversionRecord>()
                .Property(p => p.ConvertedAmount)
                .HasPrecision(18, 8);

            modelBuilder.Entity<ConversionRecord>()
                .Property(p => p.Amount)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Currency>()
                .HasIndex(c => c.CurrencyCode)
                .IsUnique();

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, CurrencyCode = "NGN", CurrencyName = "Nigerian Naira", Symbol = "₦" },
                new Currency { Id = 2, CurrencyCode = "USD", CurrencyName = "US Dollar", Symbol = "$" },
                new Currency { Id = 3, CurrencyCode = "EUR", CurrencyName = "Euro", Symbol = "€" },
                new Currency { Id = 4, CurrencyCode = "GBP", CurrencyName = "British Pound Sterling", Symbol = "£" }
            );
        }
    }
}