namespace ECOD.Domain.Entities;

public sealed class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    // ...
}