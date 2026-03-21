using Microsoft.AspNetCore.Mvc;
using Cambist.Infrastructure.Interfaces;
using Cambist.Core.Models;
using Cambist.Core.Models.Responses;
using Cambist.Core.Models.Requests;

namespace Cambist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistItemsController : ControllerBase
    {
        private readonly IWatchlistService _watchlist;

        public WatchlistItemsController(IWatchlistService watchlist)
        {
            _watchlist = watchlist;
        }

        // GET: api/WatchlistItems
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<WatchlistItemResponse>>>> GetWatchlistItems(
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _watchlist.GetAllAsync(pageNumber, pageSize);
            return Ok(response);
        }

        // POST: api/WatchlistItems
        [HttpPost]
        public async Task<ActionResult<ApiResponse<WatchlistItemResponse>>> PostWatchlistItem(AddWatchlistItemRequest item)
        {
            var response = await _watchlist.AddAsync(item);
            return Ok(response);
        }

        // DELETE: api/WatchlistItems/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<WatchlistItemResponse>>> DeleteWatchlistItem(int id)
        {
            var response = await _watchlist.DeleteAsync(id);

            return Ok(response);
        }
    }
}
