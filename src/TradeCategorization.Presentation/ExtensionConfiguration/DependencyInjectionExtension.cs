using TradeCategorization.Application.UseCases;
using TradeCategorization.Application;
using TradeCategorization.Domain.Interfaces;
using TradeCategorization.Domain.Services;
using TradeCategorization.Infrastructure.Strategies;

namespace TradeCategorization.API.ExtensionConfiguration
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder) {

            builder.Services.AddScoped<ICategorizeTradesUseCase, CategorizeTradesUseCase>();

            builder.Services.AddScoped<ITradeCategorizerStrategy, HighRiskCategoryStrategy>();
            builder.Services.AddScoped<ITradeCategorizerStrategy, LowRiskCategoryStrategy>();
            builder.Services.AddScoped<ITradeCategorizerStrategy, MediumRiskCategoryStrategy>();

            builder.Services.AddScoped<TradeCategorizerService>();
        }
    }
}
