using System.Data;
using ECOD.Application.Features.CQRS.Commands;
using ECOD.Application.Interfaces;
using ECOD.Domain.Entities;
using MediatR;

namespace ECOD.Application.Features.CQRS.Handlers.CommandHandlers;

public class CreateOrderCommandCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
{
    private readonly IOrderContext _db;

    public CreateOrderCommandCommandHandler(IOrderContext db)
    {
        _db = db;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // not real implementation
        // i would try different approach if i had enough time (not optimistic lock) :)

        await using var tx = await _db.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken);
        try
        {
            _db.Orders.Add(new Order
            {
                OrderItems = request.OrderItems.Select(oi => new OrderItem()
                {
                    Price = oi.Price,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    // ....
                }).ToList(),
            });
            await _db.SaveChangesAsync(cancellationToken);

            await tx.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            // log etc
            await tx.RollbackAsync(cancellationToken);
        }

        return Unit.Value;
    }
}