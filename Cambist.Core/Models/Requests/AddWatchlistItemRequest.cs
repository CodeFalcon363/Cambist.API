using System.ComponentModel.DataAnnotations;

namespace Cambist.Core.Models.Requests
{
    public class AddWatchlistItemRequest
    {
        [Required]
        public string BaseCurrency { get; set; }
        [Required]
        public string TargetCurrency { get; set; }
    }
}
