using TradeCategorization.Domain.Entities;

namespace TradeCategorization.Domain.Interfaces
{
    public interface ITradeCategorizerStrategy
    {
        string GetCategory(Trade trade);
    }
}
