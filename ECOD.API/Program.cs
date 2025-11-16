using ECOD.Application;
using ECOD.Application.Features.CQRS.Commands;
using ECOD.Application.Features.CQRS.Queries;
using ECOD.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/orders/{id:int}", async (int id, IMediator mediator, CancellationToken token) =>
{
    var order = await mediator.Send(new GetOrderDetailQuery(id), token);
    return Results.Ok(order);
});

app.MapGet("/api/orders", async (IMediator mediator, CancellationToken token) =>
{
    var orders = await mediator.Send(new ListOrdersQuery(), token);
    return Results.Ok(orders);
});


app.MapPost("/api/oders", async (CreateOrderCommand cmd, IMediator mediator, CancellationToken token) =>
{
    await mediator.Send(cmd, token);
    return Results.Created();
});

app.MapDelete("/api/books/{id:int}", async (int id, IMediator mediator, CancellationToken token) =>
{
    await mediator.Send(new RemoveOrderCommand(id), token);
    return Results.NoContent();
});


app.Run();