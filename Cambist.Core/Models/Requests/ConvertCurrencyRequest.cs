using System.ComponentModel.DataAnnotations;

namespace Cambist.Core.Models.Requests
{
    public class ConvertCurrencyRequest
    {
        [Required]
        public string FromCurrency { get; set; }
        [Required]
        public string ToCurrency { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
