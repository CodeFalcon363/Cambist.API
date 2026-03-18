namespace Cambist.Core.Models.Responses
{
    public class ExchangeRateResponse
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Rate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
