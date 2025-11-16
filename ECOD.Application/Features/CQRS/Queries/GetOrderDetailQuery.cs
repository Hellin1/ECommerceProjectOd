using ECOD.Application.Dtos;
using MediatR;

namespace ECOD.Application.Features.CQRS.Queries;

public sealed class GetOrderDetailQuery : IRequest<OrderListDto>
{
    public GetOrderDetailQuery(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; set; }
}