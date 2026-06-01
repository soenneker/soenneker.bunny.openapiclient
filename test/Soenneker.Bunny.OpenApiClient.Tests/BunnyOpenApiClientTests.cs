using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bunny.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BunnyOpenApiClientTests : HostedUnitTest
{
    public BunnyOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
