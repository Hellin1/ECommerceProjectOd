using ECOD.Application.Dtos;
using ECOD.Application.Features.CQRS.Queries;
using ECOD.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECOD.Application.Features.CQRS.Handlers.QueryHandlers;

public sealed class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderListDto>
{
    private readonly IOrderContext _db;

    public GetOrderDetailQueryHandler(IOrderContext db)
    {
        _db = db;
    }

    public async Task<OrderListDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var order = await _db.Orders.Select(o => new OrderListDto
        {
            // 
            Id = o.Id,
            OrderItems = o.OrderItems.Select(oi => new OrderItemListDto()
            {
                //.
            }).ToList(),
            Quantity = o.Quantity,
            CreatedAt = o.CreatedAt,
            TotalAmount = o.TotalPrice,
            UpdatedAt = o.UpdatedAt
        }).SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

        return order;
    }
}