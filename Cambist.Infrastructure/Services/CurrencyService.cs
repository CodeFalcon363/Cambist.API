using AutoMapper;
using Cambist.Core.Constants;
using Cambist.Core.Entities;
using Cambist.Core.Models;
using Cambist.Core.Models.Responses;
using Cambist.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;


namespace Cambist.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ILogger<CurrencyService> _logger;
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currency;

        public CurrencyService(ILogger<CurrencyService> logger, IMapper mapper, ICurrencyRepository currency)
        {
            _logger = logger;
            _mapper = mapper;
            _currency = currency;
        }

        public async Task<PagedResponse<IEnumerable<CurrencyResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (data, totalRecords) = await _currency.GetAllAsync(pageNumber, pageSize);

                var mappedCurrency = _mapper.Map<IEnumerable<CurrencyResponse>>(data);
                var response = new PagedResponse<IEnumerable<CurrencyResponse>>
                {
                    Success = true,
                    Message = ApiMessages.RecordsRetrieved,
                    Data = mappedCurrency,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords,
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new PagedResponse<IEnumerable<CurrencyResponse>>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }
        public async Task<ApiResponse<CurrencyResponse>> GetByCodeAsync(string code)
        {
            try
            {
                var currency = await _currency.GetByCodeAsync(code);
                var mappedCurrency = _mapper.Map<CurrencyResponse>(currency);
                var response = new ApiResponse<CurrencyResponse>
                {
                    Success = true,
                    Message = ApiMessages.RecordRetrieved,
                    Data = mappedCurrency
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ApiResponse<CurrencyResponse>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }
    }
}
