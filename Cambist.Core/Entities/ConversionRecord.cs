namespace Cambist.Core.Entities
{
    public class ConversionRecord
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public decimal Rate { get; set; }
        public DateTime ConvertedAt { get; set; }
    }
}
