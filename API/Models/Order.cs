namespace API.Models;
public class Order
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public bool IsAccepted { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public string Table { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
}
