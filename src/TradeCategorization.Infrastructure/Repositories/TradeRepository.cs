using TradeCategorization.Domain.Entities;
using TradeCategorization.Infrastructure.Data;

namespace TradeCategorization.Infrastructure.Repositories
{
    public class TradeRepository
    {
        private readonly TradeContext _context;

        public TradeRepository(TradeContext context)
        {
            _context = context;
        }

        public List<Trade> GetAllTrades()
        {
            return _context.Trades.ToList();
        }
    }
}
