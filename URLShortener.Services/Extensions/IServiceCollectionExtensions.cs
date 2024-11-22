using Microsoft.Extensions.DependencyInjection;
using URLShortener.Services.Abstractions;

namespace URLShortener.Services.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IUrlService, UrlService>();
    }
}
