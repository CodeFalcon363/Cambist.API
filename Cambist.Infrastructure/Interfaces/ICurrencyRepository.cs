using Cambist.Core.Entities;

namespace Cambist.Infrastructure.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency?> GetByCodeAsync(string code);
    }
}
