using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cambist.Core.Data;
using Cambist.Core.Entities;
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
        public async Task<ActionResult<PagedResponse<IEnumerable<ConversionRecord>>>> GetConversionRecords(
            [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await _conversion.GetAllAsync(pageNumber, pageSize);
            return Ok(response);
        }

        // GET: api/ConversionRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ConversionRecord>>> GetConversionRecord(int id)
        {
            var response = await _conversion.GetByIdAsync(id);
            return Ok(response);
        }

        // POST: api/ConversionRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ConversionRecordResponse>>> PostConversionRecord(ConvertCurrencyRequest record)
        {
            var response = await _conversion.AddAsync(record);
            return Ok(response);
        }
    }
}
