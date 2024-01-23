namespace TetePizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }

    public List<Ingredientes> Ingredientes { get; set; }
}
