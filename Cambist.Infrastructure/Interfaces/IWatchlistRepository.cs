using Cambist.Core.Entities;
namespace Cambist.Infrastructure.Interfaces
{
    public interface IWatchlistRepository
    {
        Task<WatchlistItem> AddAsync(WatchlistItem item);
        Task<IEnumerable<WatchlistItem>> GetAllAsync();
        Task DeleteAsync(int id);
        
    }
}
