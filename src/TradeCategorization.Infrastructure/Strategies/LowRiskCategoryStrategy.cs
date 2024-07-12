using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.Interfaces;

namespace TradeCategorization.Infrastructure.Strategies
{
    public class LowRiskCategoryStrategy : ITradeCategorizerStrategy
    {
        public string GetCategory(Trade trade)
        {
            if (trade.Value < 1000000 && trade.ClientSector == "Public")
                return "LOWRISK";
            return null;
        }
    }
}
