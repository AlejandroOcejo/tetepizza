namespace TetePizza.Data;
using TetePizza.Models;

public class IngredientesRepository : IIngredientesRepository
{
    private List<Ingredientes> Ingredientess { get; } = new List<Ingredientes>();
    private int nextId = 1;

    public List<Ingredientes> GetAll() => Ingredientess;

    public Ingredientes? Get(int id) => Ingredientess.FirstOrDefault(p => p.Id == id);

    public void Add(Ingredientes Ingredientes)
    {
        Ingredientes.Id = nextId++;
        Ingredientess.Add(Ingredientes);
    }

    public void Delete(int id)
    {
        var Ingredientes = Get(id);
        if (Ingredientes is null)
            return;

        Ingredientess.Remove(Ingredientes);
    }

    public void Update(Ingredientes Ingredientes)
    {
        var index = Ingredientess.FindIndex(p => p.Id == Ingredientes.Id);
        if (index == -1)
            return;

        Ingredientess[index] = Ingredientes;
    }
}
