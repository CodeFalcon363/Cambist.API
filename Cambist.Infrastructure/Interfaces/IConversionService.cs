using Cambist.Core.Models.Responses;
using Cambist.Core.Models.Requests;
using Cambist.Core.Models;


namespace Cambist.Infrastructure.Interfaces
{
    public interface IConversionService 
    {
        Task <ApiResponse<ConversionRecordResponse>> AddAsync(ConvertCurrencyRequest record);
        Task<PagedResponse<IEnumerable<ConversionRecordResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<ApiResponse<ConversionRecordResponse>> GetByIdAsync(int id);
    }
}
