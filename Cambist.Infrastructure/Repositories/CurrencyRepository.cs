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

        public async Task<(IEnumerable<Currency>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize)
        {   
            var totalCount = await _context.Currencies.CountAsync();
            var pagedData = await _context.Currencies
                .Skip((pageNumber - 1)* pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return (pagedData, totalCount);
        }

        public async Task<Currency?> GetByCodeAsync(string code)
        {
            var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == code);
            return currency;
        }
    }
}
