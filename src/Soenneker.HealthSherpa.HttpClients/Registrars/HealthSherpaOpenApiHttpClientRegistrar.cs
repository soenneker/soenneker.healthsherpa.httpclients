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
    /// Adds the HealthSherpa HTTP client provider and its cache as singleton services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddHealthSherpaOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IHealthSherpaOpenApiHttpClient, HealthSherpaOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds the HealthSherpa HTTP client provider and its cache as scoped services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddHealthSherpaOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsScoped()
                .TryAddScoped<IHealthSherpaOpenApiHttpClient, HealthSherpaOpenApiHttpClient>();

        return services;
    }
}
