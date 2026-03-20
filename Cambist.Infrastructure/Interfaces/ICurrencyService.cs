using Cambist.Core.Models;
using Cambist.Core.Models.Responses;

namespace Cambist.Infrastructure.Interfaces
{
    public interface ICurrencyService
    {
        Task<PagedResponse<IEnumerable<CurrencyResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<ApiResponse<CurrencyResponse>> GetByCodeAsync(string code);
    }
}
