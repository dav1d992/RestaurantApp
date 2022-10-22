namespace API.Models;
public class Menu
{
    public int Id { get; set; }
    public ICollection<MenuItem> Items { get; set; }
}
