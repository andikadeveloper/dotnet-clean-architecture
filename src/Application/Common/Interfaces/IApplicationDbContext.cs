using dotnet_clean_architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_clean_architecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
