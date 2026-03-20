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
            services.AddScoped<ExchangeRateService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            return services;
        }
    }
}
