namespace API.Models;
public class MenuItem
{
    public int Id { get; set; }
    public bool Available { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Price { get; set; }
    public int MenuId { get; set; }
}
