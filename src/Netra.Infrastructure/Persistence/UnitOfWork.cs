using Netra.Core.Interfaces;

namespace Netra.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly NetraDbContext _dbContext;

    public UnitOfWork(NetraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await _dbContext.SaveChangesAsync(ct);
}
