using Microsoft.EntityFrameworkCore;
using SecondTest.Entities;

namespace SecondTest.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges();
    }
}
