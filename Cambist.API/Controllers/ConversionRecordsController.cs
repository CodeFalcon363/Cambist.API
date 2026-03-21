using Microsoft.AspNetCore.Mvc;
using Cambist.Infrastructure.Interfaces;
using Cambist.Core.Models;
using Cambist.Core.Models.Requests;
using Cambist.Core.Models.Responses;

namespace Cambist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionRecordsController : ControllerBase
    {
        private readonly IConversionService _conversion;

        public ConversionRecordsController(IConversionService conversion)
        {
            _conversion = conversion;
        }

        // GET: api/ConversionRecords
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<ConversionRecordResponse>>>> GetConversionRecords(
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _conversion.GetAllAsync(pageNumber, pageSize);
            return Ok(response);
        }

        // GET: api/ConversionRecords/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ConversionRecordResponse>>> GetConversionRecord(int id)
        {
            var response = await _conversion.GetByIdAsync(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        // POST: api/ConversionRecords
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ConversionRecordResponse>>> PostConversionRecord(ConvertCurrencyRequest record)
        {
            var response = await _conversion.AddAsync(record);
            return Ok(response);
        }
    }
}
