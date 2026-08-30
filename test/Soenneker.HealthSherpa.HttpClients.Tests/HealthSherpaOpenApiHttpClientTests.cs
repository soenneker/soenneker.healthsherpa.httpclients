using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.HealthSherpa.HttpClients.Abstract;
using Soenneker.HealthSherpa.HttpClients.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.HealthSherpa.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class HealthSherpaOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IHealthSherpaOpenApiHttpClient _httpclient;

    public HealthSherpaOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IHealthSherpaOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_registration_owns_an_independent_cache()
    {
        var services = new ServiceCollection();

        services.AddHealthSherpaOpenApiHttpClientAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IHealthSherpaOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
