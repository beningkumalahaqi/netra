using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Netra.Infrastructure.Persistence;

namespace Netra.IntegrationTests;

/// <summary>
/// Base class for integration tests that sets up a WebApplicationFactory
/// with an in-memory database for testing.
/// </summary>
public abstract class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly WebApplicationFactory<Program> Factory;
    protected readonly HttpClient Client;

    protected IntegrationTestBase(WebApplicationFactory<Program> factory)
    {
        Factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<DbContextOptions<NetraDbContext>>();

                services.AddDbContext<NetraDbContext>(options =>
                {
                    options.UseInMemoryDatabase("NetraTestDb");
                });
            });
        });

        Client = Factory.CreateClient();
    }
}
