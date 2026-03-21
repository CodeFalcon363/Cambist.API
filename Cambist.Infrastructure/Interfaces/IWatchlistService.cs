using Cambist.Core.Models;
using Cambist.Core.Models.Responses;
using Cambist.Core.Models.Requests;


namespace Cambist.Infrastructure.Interfaces
{
    public interface IWatchlistService
    {
        Task<ApiResponse<WatchlistItemResponse>> AddAsync(AddWatchlistItemRequest item);
        Task<PagedResponse<IEnumerable<WatchlistItemResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<ApiResponse<WatchlistItemResponse>> DeleteAsync(int id);

    }
}
