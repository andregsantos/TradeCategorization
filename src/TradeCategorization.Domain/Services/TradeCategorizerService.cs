using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.Interfaces;
using TradeCategorization.Domain.ValueObjects;

namespace TradeCategorization.Domain.Services
{
    public class TradeCategorizerService
    {
        private readonly IEnumerable<ITradeCategorizerStrategy> _strategies;

        public TradeCategorizerService(IEnumerable<ITradeCategorizerStrategy> strategies)
        {
            _strategies = strategies;
        }

        public List<TradeCategory> CategorizeTrades(List<Trade> portfolio)
        {
            var categories = new List<TradeCategory>();

            foreach (var trade in portfolio)
            {
                foreach (var strategy in _strategies)
                {
                    var category = strategy.GetCategory(trade);
                    if (category != null)
                    {
                        categories.Add(new TradeCategory(category));
                        break;
                    }
                }
            }

            return categories;
        }
    }
}
