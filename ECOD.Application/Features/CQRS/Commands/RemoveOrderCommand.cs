using MediatR;

namespace ECOD.Application.Features.CQRS.Commands;

public sealed class RemoveOrderCommand : IRequest<Unit>
{
    public RemoveOrderCommand(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; set; }
}