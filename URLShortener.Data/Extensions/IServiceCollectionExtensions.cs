using Microsoft.Extensions.DependencyInjection;
using URLShortener.Data.Abstractions;

namespace URLShortener.Data.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDataStores(this IServiceCollection services)
    {
        return services
            .AddTransient<IUrlDataStore, UrlDataStore>();
    }
}
