using Cambist.Core.Entities;

namespace Cambist.Infrastructure.Interfaces
{
    public interface IConversionRepository
    {
        Task<ConversionRecord> AddAsync(ConversionRecord record);
        Task<IEnumerable<ConversionRecord>> GetAllAsync();
        Task<ConversionRecord?> GetByIdAsync(int id);
    }
}
