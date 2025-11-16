using ECOD.Application.Dtos;
using ECOD.Application.Features.CQRS.Queries;
using ECOD.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECOD.Application.Features.CQRS.Handlers.QueryHandlers;

public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery, List<OrderListDto>>
{
    private readonly IOrderContext _db;

    public ListOrdersQueryHandler(IOrderContext db)
    {
        _db = db;
    }

    public async Task<List<OrderListDto>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _db.Orders.Select(o => new OrderListDto
        {
            Id = o.Id,
            OrderItems = o.OrderItems.Select(oi => new OrderItemListDto
            {
                //..
            }).ToList(),
            Quantity = o.Quantity,
            TotalAmount = o.TotalPrice,
            CreatedAt = o.CreatedAt,
            UpdatedAt = o.UpdatedAt
        }).ToListAsync(cancellationToken);
        return orders;
    }
}