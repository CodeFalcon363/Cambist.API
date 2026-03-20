using AutoMapper;
using Cambist.Core.Constants;
using Cambist.Core.Entities;
using Cambist.Core.Models;
using Cambist.Core.Models.Requests;
using Cambist.Core.Models.Responses;
using Cambist.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cambist.Infrastructure.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly ILogger<WatchlistService> _logger;
        private readonly IMapper _mapper;
        private readonly IWatchlistRepository _watchlist;

        public WatchlistService(ILogger<WatchlistService> logger, IMapper mapper, IWatchlistRepository watchlist)
        {
            _logger = logger;
            _mapper = mapper;
            _watchlist = watchlist;
        }

        public async Task<ApiResponse<WatchlistItemResponse>> AddAsync(AddWatchlistItemRequest item)
        {
            try
            {
                var mappedRequest = _mapper.Map<WatchlistItem>(item);
                var addedItem = await _watchlist.AddAsync(mappedRequest);
                var mappedResponse = _mapper.Map<WatchlistItemResponse>(addedItem);
                var response = new ApiResponse<WatchlistItemResponse>
                {
                    Success = true,
                    Message = ApiMessages.WatchlistItemAdded,
                    Data = mappedResponse
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ApiResponse<WatchlistItemResponse>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }

        public async Task<ApiResponse<WatchlistItemResponse>> DeleteAsync(int id)
        {
            try
            {
                await _watchlist.DeleteAsync(id);
                return new ApiResponse<WatchlistItemResponse>
                {
                    Success = true,
                    Message = ApiMessages.RecordDeleted
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ApiResponse<WatchlistItemResponse>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }

        public async Task<PagedResponse<IEnumerable<WatchlistItemResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (items, totalCount) = await _watchlist.GetAllAsync(pageNumber, pageSize);
                var mappedResponse = _mapper.Map<IEnumerable<WatchlistItemResponse>>(items);
                var response = new PagedResponse<IEnumerable<WatchlistItemResponse>>
                {
                    Success = true,
                    Message = ApiMessages.RecordsRetrieved,
                    Data = mappedResponse,
                    TotalRecords = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new PagedResponse<IEnumerable<WatchlistItemResponse>>
                {
                    Success = false,
                    Message = ApiMessages.InternalError
                };
            }
        }
    }
}
