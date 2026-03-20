using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cambist.Core.Data;
using Cambist.Core.Entities;
using AutoMapper;
using Cambist.Infrastructure.Interfaces;
using Cambist.Core.Constants;
using Cambist.Core.Models.Responses;
using Cambist.Core.Models;
namespace Cambist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currency;

        public CurrencyController(ICurrencyService currency )
        {
           _currency = currency;
        }

        // GET: api/Currency
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CurrencyResponse>>> GetCurrencies(
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {   
            var currencies = await _currency.GetAllAsync(pageNumber, pageSize );
            return Ok(currencies);

        }

        // GET: api/Currency/{code}
        [HttpGet("{code}")]
        public async Task<ActionResult<CurrencyResponse>> GetCurrency(string code)
        {
            var currency = await _currency.GetByCodeAsync(code);
            return Ok(currency);
        }
    }
}
