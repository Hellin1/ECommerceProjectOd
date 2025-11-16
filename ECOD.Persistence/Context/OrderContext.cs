using System.Data;
using ECOD.Application.Interfaces;
using ECOD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECOD.Persistence.Context;

public class OrderContext : DbContext, IOrderContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public Task<IDbContextTransaction> BeginTransactionAsync(
        IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
        CancellationToken ct = default)
    {
        return Database.BeginTransactionAsync(isolationLevel, ct);
    }

    public DbSet<OrderItem> OrderItems { get; set; }
}