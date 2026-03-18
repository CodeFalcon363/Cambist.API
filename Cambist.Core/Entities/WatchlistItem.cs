namespace Cambist.Core.Entities
{
    public class WatchlistItem
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
