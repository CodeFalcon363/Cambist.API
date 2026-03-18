using Cambist.Core.Models.Responses;
using RestSharp;

namespace Cambist.Infrastructure.ExternalServices
{
    public class ExchangeRateService
    {
        
        private readonly RestClient _client;

        public ExchangeRateService()
        {
            _client = new RestClient("https://open.er-api.com/v6/");
        }
        public async Task<ExchangeRateResponse?> GetExchangeRateAsync(string baseCurrency, string targetCurrency)
        {
            var request = new RestRequest($"latest/{baseCurrency}");
            var response = await _client.ExecuteAsync<ExchangeRateApiResponse>(request);
            if (!response.IsSuccessful || response.Data == null ) 
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
        private class ExchangeRateApiResponse
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }

    }

}
