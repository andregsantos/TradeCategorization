using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.Services;
using TradeCategorization.Domain.ValueObjects;

namespace TradeCategorization.Application.UseCases
{
    public class CategorizeTradesUseCase: ICategorizeTradesUseCase
    {
        private readonly TradeCategorizerService _categorizerService;

        public CategorizeTradesUseCase(TradeCategorizerService categorizerService)
        {
            _categorizerService = categorizerService;
        }

        public List<TradeCategory> Execute(List<Trade> trades)
        {
            return _categorizerService.CategorizeTrades(trades);
        }
    }
}
