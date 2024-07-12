using Microsoft.EntityFrameworkCore;
using TradeCategorization.Domain.Entities;

namespace TradeCategorization.Infrastructure.Data
{
    public class TradeContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        public TradeContext(DbContextOptions<TradeContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConnectionStrings");
        }
    }
}
