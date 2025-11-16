using ECOD.Application.Features.CQRS.Commands;
using ECOD.Application.Interfaces;
using ECOD.Domain.Entities;
using MediatR;

namespace ECOD.Application.Features.CQRS.Handlers.CommandHandlers;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, Unit>
{
    private readonly IOrderContext _db;

    public RemoveOrderCommandHandler(IOrderContext db)
    {
        _db = db;
    }

    public async Task<Unit> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        _db.Orders.Remove(new Order { Id = request.OrderId });
        await _db.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}