namespace Cambist.Core.Models.Responses
{
    public class WatchlistItemResponse
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
