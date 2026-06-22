using Microsoft.AspNetCore.Mvc.Testing;

namespace Netra.IntegrationTests.Api;

public class HealthCheckTests : IntegrationTestBase
{
    public HealthCheckTests(WebApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task GetHealth_Returns200()
    {
        var response = await Client.GetAsync("/health");

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
