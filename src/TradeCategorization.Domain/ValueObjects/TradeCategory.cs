namespace TradeCategorization.Domain.ValueObjects
{
    public class TradeCategory
    {
        public string Category { get; private set; }

        public TradeCategory(string category)
        {
            Category = category;
        }
    }
}