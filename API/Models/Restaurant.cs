namespace API.Models;
public class Restaurant
{
    public int Id { get; set; }
    public int Cvr { get; set; }
    public string Name { get; set; }
    public string ImageURL { get; set; }
    public Address Address { get; set; }
    public User Owner { get; set; }
    public int NumberOfTables { get; set; }
    public ICollection<Order> Orders { get; set; }
    public Menu Menu { get; set; }
}
