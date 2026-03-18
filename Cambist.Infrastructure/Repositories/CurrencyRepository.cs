using Cambist.Core.Data;
using Cambist.Core.Entities;
using Cambist.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cambist.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CambistDbContext _context;

        public CurrencyRepository(CambistDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            var currencies = await _context.Currencies.ToListAsync();
            return currencies;
        }

        public async Task<Currency?> GetByCodeAsync(string code)
        {
            var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == code);
            return currency;
        }
    }
}
