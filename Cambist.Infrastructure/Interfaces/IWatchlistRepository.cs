using Cambist.Core.Entities;

namespace Cambist.Infrastructure.Interfaces
{
    public interface IWatchlistRepository
    {
        Task<WatchlistItem> AddAsync(WatchlistItem item);
        Task<(IEnumerable<WatchlistItem>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);
        Task DeleteAsync(int id);
        
    }
}
