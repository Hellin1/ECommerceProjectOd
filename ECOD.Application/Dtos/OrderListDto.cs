namespace ECOD.Application.Dtos;

public class OrderListDto
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public int Quantity { get; set; }
    public List<OrderItemListDto> OrderItems { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    //...
}