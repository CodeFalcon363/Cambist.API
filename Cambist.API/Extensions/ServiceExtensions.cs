using AutoMapper;
using Cambist.Infrastructure.ExternalServices;
using Cambist.Infrastructure.Interfaces;
using Cambist.Infrastructure.Mappings;
using Cambist.Infrastructure.Repositories;
using Cambist.Infrastructure.Services;

namespace Cambist.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)    
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddScoped<IConversionRepository, ConversionRepository>();
            services.AddScoped<IWatchlistRepository, WatchlistRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IWatchlistService, WatchlistService>();
            services.AddScoped<IConversionService, ConversionService>();
            return services;
        }
    }
}
