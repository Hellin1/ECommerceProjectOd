using ECOD.Application.Dtos;
using MediatR;

namespace ECOD.Application.Features.CQRS.Commands;

public sealed class CreateOrderCommand : IRequest<Unit>
{
    public int UserId { get; set; }
    public List<OrderItemCreateDto> OrderItems { get; set; }
}