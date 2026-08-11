using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.HealthSherpa.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.HealthSherpa.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class HealthSherpaOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="HealthSherpaOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddHealthSherpaOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IHealthSherpaOpenApiHttpClient, HealthSherpaOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="HealthSherpaOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddHealthSherpaOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IHealthSherpaOpenApiHttpClient, HealthSherpaOpenApiHttpClient>();

        return services;
    }
}
