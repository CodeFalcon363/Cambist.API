using Cambist.Core.Data;
using Cambist.Core.Entities;
using Cambist.Core.Models.Requests;
using Cambist.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cambist.Infrastructure.Repositories
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly CambistDbContext _context;

        public ConversionRepository(CambistDbContext context)
        {
            _context = context;
        }
        public async Task<ConversionRecord> AddAsync(ConvertCurrencyRequest request, decimal rate, decimal convertedAmount)
        {
            var record = new ConversionRecord
            {
                FromCurrency = request.FromCurrency,
                ToCurrency = request.ToCurrency,
                Amount = request.Amount,
                ConvertedAmount = convertedAmount,
                Rate = rate,
                ConvertedAt = DateTime.UtcNow
            };
            await _context.ConversionRecords.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<(IEnumerable<ConversionRecord>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.ConversionRecords.CountAsync();
            var records = await _context.ConversionRecords
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (records, totalCount);
        }

        public async Task<ConversionRecord?> GetByIdAsync(int id)
        {
            var record = await _context.ConversionRecords.FindAsync(id);
            return record;
        }
    }
}
