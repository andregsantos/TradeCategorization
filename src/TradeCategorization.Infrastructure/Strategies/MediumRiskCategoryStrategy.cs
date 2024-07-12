using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.Interfaces;

namespace TradeCategorization.Infrastructure.Strategies
{
    public class MediumRiskCategoryStrategy : ITradeCategorizerStrategy
    {
        public string GetCategory(Trade trade)
        {
            if (trade.Value >= 1000000 && trade.ClientSector == "Public")
                return "MEDIUMRISK";
            return null;
        }
    }
}
