using AutoMapper;
using Cambist.Core.Constants;
using Cambist.Core.Models;
using Cambist.Core.Models.Requests;
using Cambist.Core.Models.Responses;
using Cambist.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cambist.Infrastructure.Services
{
    public class ConversionService : IConversionService
    {
        private readonly ILogger<ConversionService> _logger;
        private readonly IMapper _mapper;
        private readonly IConversionRepository _record;
        private readonly IExchangeRateService _exchangeservice;

        public ConversionService(ILogger<ConversionService> logger, IMapper mapper, IConversionRepository record, IExchangeRateService exchangeService)
        {
            _logger = logger;
            _mapper = mapper;
            _record = record;
            _exchangeservice = exchangeService;
        }

        public async Task<ApiResponse<ConversionRecordResponse>> AddAsync(ConvertCurrencyRequest request)
        {
            try
            {
                var exchangeRate = await _exchangeservice.GetExchangeRateAsync(request.FromCurrency, request.ToCurrency);
                if (exchangeRate == null)
                {
                    return new ApiResponse<ConversionRecordResponse>
                    {
                        Success = false,
                        Message = ApiMessages.ExchangeRateFetchFailed
                    };
                }
                var rate = exchangeRate.Rate;
                var convertedAmount = rate * request.Amount;
                var conversion = await _record.AddAsync(request, rate, convertedAmount );

                var mappedResponse = _mapper.Map<ConversionRecordResponse>(conversion);
                var response = new ApiResponse<ConversionRecordResponse>
                {
                    Success = true,
                    Message = ApiMessages.ConversionSuccess,
                    Data = mappedResponse
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ApiResponse<ConversionRecordResponse>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }

        public async Task<PagedResponse<IEnumerable<ConversionRecordResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (data, totalCount) = await _record.GetAllAsync(pageNumber, pageSize);
                var mappedResponse = _mapper.Map<IEnumerable<ConversionRecordResponse>>(data);
                var response = new PagedResponse<IEnumerable<ConversionRecordResponse>>
                {
                    Success = true,
                    Message = ApiMessages.RecordsRetrieved,
                    Data = mappedResponse,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalCount
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new PagedResponse<IEnumerable<ConversionRecordResponse>>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }

        public async Task<ApiResponse<ConversionRecordResponse?>> GetByIdAsync(int id)
        {
            try
            {
                var record = await _record.GetByIdAsync(id);
                var mappedResponse = _mapper.Map<ConversionRecordResponse>(record);
                var response = new ApiResponse<ConversionRecordResponse>
                {
                    Success = true,
                    Message = ApiMessages.RecordRetrieved,
                    Data = mappedResponse
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ApiResponse<ConversionRecordResponse?>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }
    }
}
