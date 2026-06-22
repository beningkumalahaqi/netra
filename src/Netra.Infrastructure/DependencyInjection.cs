using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Netra.Core.Interfaces;
using Netra.Infrastructure.Persistence;

namespace Netra.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<NetraDbContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
                npgsql.MigrationsAssembly(typeof(NetraDbContext).Assembly.FullName))
            .UseSnakeCaseNamingConvention());

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
