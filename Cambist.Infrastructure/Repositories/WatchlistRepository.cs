using Cambist.Core.Data;
using Cambist.Core.Entities;
using Cambist.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cambist.Infrastructure.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly CambistDbContext _context;

        public WatchlistRepository(CambistDbContext context)
        {
           _context = context;
        }
        public async Task<WatchlistItem> AddAsync(WatchlistItem item)
        {
            await _context.WatchlistItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.WatchlistItems.FindAsync(id);

            if (item != null)
            {
                _context.WatchlistItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<WatchlistItem>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.WatchlistItems.CountAsync();
            var watchlistItem = await _context.WatchlistItems
                .Skip((pageNumber -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (watchlistItem, totalCount);
        }
    }
}
