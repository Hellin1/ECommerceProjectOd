using ECOD.Application.Dtos;
using MediatR;

namespace ECOD.Application.Features.CQRS.Queries;

public sealed class ListOrdersQuery : IRequest<List<OrderListDto>>
{
}