using Cambist.Core.Models.Responses;
using Cambist.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Cambist.Infrastructure.ExternalServices
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly RestClient _client;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(IConfiguration configuration, ILogger<ExchangeRateService> logger)
        {
            _logger = logger;
            _client = new RestClient(configuration["ExchangeRateApi:BaseUrl"]);
        }
        public async Task<ExchangeRateResponse?> GetExchangeRateAsync(string baseCurrency, string targetCurrency)
        {
            try
            {
                var request = new RestRequest($"latest/{baseCurrency}");
                var response = await _client.ExecuteAsync<ExchangeRateApiResponse>(request);
                if (!response.IsSuccessful || response.Data == null)
                {
                    return null;
                }
                bool found = response.Data.Rates.TryGetValue
                    (targetCurrency.ToUpper(), out decimal rate);
                if (!found)
                {
                    return null;
                }

                return new ExchangeRateResponse
                {
                    BaseCurrency = baseCurrency.ToUpper(),
                    TargetCurrency = targetCurrency.ToUpper(),
                    Rate = rate,
                    Timestamp = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        private class ExchangeRateApiResponse
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }

    }

}
