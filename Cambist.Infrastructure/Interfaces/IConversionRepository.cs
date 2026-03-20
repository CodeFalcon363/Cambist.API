using Cambist.Core.Entities;

namespace Cambist.Infrastructure.Interfaces
{
    public interface IConversionRepository
    {
        Task<ConversionRecord> AddAsync(ConversionRecord record);
        Task<(IEnumerable<ConversionRecord>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);
        Task<ConversionRecord?> GetByIdAsync(int id);
    }
}
