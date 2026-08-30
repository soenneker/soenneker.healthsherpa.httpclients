using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.HealthSherpa.HttpClients.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured for the HealthSherpa API.
/// </summary>
public interface IHealthSherpaOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured HTTP client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The client cached for this provider's lifetime.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
