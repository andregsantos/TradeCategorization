using Microsoft.EntityFrameworkCore;
using TradeCategorization.Infrastructure.Data;

namespace TradeCategorization.API.ExtensionConfiguration
{
    public static class OptionExtension
    {
        public static void AddOptions(this WebApplicationBuilder builder) {
            builder.Services.AddDbContext<TradeContext>(options => options.UseSqlServer("ConnectionStrings"));
        }
    }
}
