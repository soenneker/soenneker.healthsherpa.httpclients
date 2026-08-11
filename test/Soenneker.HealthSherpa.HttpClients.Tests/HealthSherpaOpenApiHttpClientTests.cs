using Soenneker.HealthSherpa.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
