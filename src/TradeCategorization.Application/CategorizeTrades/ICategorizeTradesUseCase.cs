using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.ValueObjects;

namespace TradeCategorization.Application
{
    public interface ICategorizeTradesUseCase
    {
        public List<TradeCategory> Execute(List<Trade> trades);
    }
}
