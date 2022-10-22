namespace API.Models;
public class OrderLine
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public MenuItem MenuItem { get; set; }
}
