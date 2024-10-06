using Microsoft.EntityFrameworkCore;

namespace Task.Core.Interfaces;

public interface ICleanDbContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

