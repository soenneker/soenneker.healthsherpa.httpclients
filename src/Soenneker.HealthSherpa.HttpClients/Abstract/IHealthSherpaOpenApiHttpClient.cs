using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.HealthSherpa.HttpClients.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IHealthSherpaOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Health Sherpa OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
