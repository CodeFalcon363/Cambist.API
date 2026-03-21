using Cambist.Core.Models.Responses;

namespace Cambist.Infrastructure.Interfaces
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateResponse?> GetExchangeRateAsync(string baseCurrency, string targetCurrency);
    }
}