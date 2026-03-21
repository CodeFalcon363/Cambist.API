using Cambist.Core.Entities;

namespace Cambist.Infrastructure.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<(IEnumerable<Currency>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);
        Task<Currency?> GetByCodeAsync(string code);
        Task<bool> ExistsAsync(string code);
    }
}
 