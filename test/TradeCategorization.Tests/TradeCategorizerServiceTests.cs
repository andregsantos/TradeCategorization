using Xunit;
using Moq;
using TradeCategorization.Domain.Entities;
using TradeCategorization.Domain.Interfaces;
using TradeCategorization.Application.UseCases;
using TradeCategorization.Application;
using TradeCategorization.Domain.Services;

namespace TradeCategorization.Tests
{
    public class TradeCategorizerServiceTests
    {
        private readonly ICategorizeTradesUseCase _categorizeTradesUseCase;
        private readonly TradeCategorizerService _tradeCategorizerService;

        private readonly Mock<ITradeCategorizerStrategy> _lowRiskStrategy;
        private readonly Mock<ITradeCategorizerStrategy> _mediumRiskStrategy;
        private readonly Mock<ITradeCategorizerStrategy> _highRiskStrategy;

        public TradeCategorizerServiceTests()
        {
            _lowRiskStrategy = new Mock<ITradeCategorizerStrategy>();
            _mediumRiskStrategy = new Mock<ITradeCategorizerStrategy>();
            _highRiskStrategy = new Mock<ITradeCategorizerStrategy>();

            var strategies = new List<ITradeCategorizerStrategy>
            {
                _lowRiskStrategy.Object,
                _mediumRiskStrategy.Object,
                _highRiskStrategy.Object
            };

            _tradeCategorizerService = new TradeCategorizerService(strategies);
            _categorizeTradesUseCase = new CategorizeTradesUseCase(_tradeCategorizerService);

        }

        [Fact]
        public void CategorizeTrades_CategorizesTradesCorrectly()
        {
            // Arrange
            var trades = new List<Trade>
            {
                new Trade { Value = 2000000, ClientSector = "Private" },
                new Trade { Value = 400000, ClientSector = "Public" },
                new Trade { Value = 500000, ClientSector = "Public" },
                new Trade { Value = 3000000, ClientSector = "Public" }
            };

            _lowRiskStrategy.Setup(s => s.GetCategory(It.IsAny<Trade>())).Returns((Trade trade) =>
            {
                if (trade.Value < 1000000 && trade.ClientSector == "Public") return "LOWRISK";
                return null;
            });

            _mediumRiskStrategy.Setup(s => s.GetCategory(It.IsAny<Trade>())).Returns((Trade trade) =>
            {
                if (trade.Value > 1000000 && trade.ClientSector == "Public") return "MEDIUMRISK";
                return null;
            });

            _highRiskStrategy.Setup(s => s.GetCategory(It.IsAny<Trade>())).Returns((Trade trade) =>
            {
                if (trade.Value > 1000000 && trade.ClientSector == "Private") return "HIGHRISK";
                return null;
            });

            // Act
            var categories = _categorizeTradesUseCase.Execute(trades);

            // Assert
            Assert.Equal(4, categories.Count);
            Assert.Equal("HIGHRISK", categories[0].Category);
            Assert.Equal("LOWRISK", categories[1].Category);
            Assert.Equal("LOWRISK", categories[2].Category);
            Assert.Equal("MEDIUMRISK", categories[3].Category);
        }
    }
}
