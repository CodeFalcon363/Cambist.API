using Cambist.Core.Entities;
using Cambist.Core.Models.Requests;

namespace Cambist.Infrastructure.Interfaces
{
    public interface IConversionRepository
    {
        Task<ConversionRecord> AddAsync(ConvertCurrencyRequest request, decimal rate, decimal convertedAmount);
        Task<(IEnumerable<ConversionRecord>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);
        Task<ConversionRecord?> GetByIdAsync(int id);
    }
}
