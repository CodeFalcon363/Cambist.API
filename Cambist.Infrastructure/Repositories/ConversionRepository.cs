using Cambist.Core.Data;
using Cambist.Core.Entities;
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
        public async Task<ConversionRecord> AddAsync(ConversionRecord record)
        {
            await _context.ConversionRecords.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<IEnumerable<ConversionRecord>> GetAllAsync()
        {
            var records = await _context.ConversionRecords.ToListAsync();
            return records;
        }

        public async Task<ConversionRecord?> GetByIdAsync(int id)
        {
            var record = await _context.ConversionRecords.FindAsync(id);
            return record;
        }
    }
}
