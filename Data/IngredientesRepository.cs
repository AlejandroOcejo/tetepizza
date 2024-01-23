namespace TetePizza.Data;
using TetePizza.Models;

public class IngredientesRepository : IIngredientesRepository
{
    private List<Ingredientes> _Ingredientes { get; } = new List<Ingredientes>();
    private int nextId = 1;

    public List<Ingredientes> GetAll() => _Ingredientes;

    public Ingredientes? Get(int id) => _Ingredientes.FirstOrDefault(p => p.Id == id);

    private IPizzaRepository _PizzaRepository;
    public IngredientesRepository(IPizzaRepository pizzaRepository)
    {
        _PizzaRepository = pizzaRepository;
    }



    public void Add(Ingredientes Ingredientes)
    {
        Ingredientes.Id = nextId++;
        _Ingredientes.Add(Ingredientes);
    }

    public void Delete(int id)
    {
        var Ingredientes = Get(id);
        if (Ingredientes is null)
            return;

        _Ingredientes.Remove(Ingredientes);
    }

    public void Update(Ingredientes Ingredientes)
    {
        var index = _Ingredientes.FindIndex(p => p.Id == Ingredientes.Id);
        if (index == -1)
            return;

        _Ingredientes[index] = Ingredientes;
    }

    public List<Ingredientes> GetPizzaIngredientes(int pizzaId)
    {
        Pizza pizza = _PizzaRepository.Get(pizzaId);

        if (pizza != null)
        {
            return pizza.Ingredientes;
        }

        return new List<Ingredientes>();
    }

    public void AddIngrediente(int pizzaId, int ingredienteId)
    {
        Pizza pizza = _PizzaRepository.Get(pizzaId);

        if (pizza != null)
        {
            if (pizza.Ingredientes.Any(i => i.Id == ingredienteId))
            {
                return;
            }

            Ingredientes ingrediente = Get(ingredienteId);

            if (ingrediente != null)
            {
                pizza.Ingredientes.Add(ingrediente);
                _PizzaRepository.Update(pizza);
            }
        }
    }


}
