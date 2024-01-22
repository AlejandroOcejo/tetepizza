namespace TetePizza.Data;
using TetePizza.Models;

public class PizzaRepository : IPizzaRepository
{
    private List<Pizza> Pizzas { get; } = new List<Pizza>();
    private int nextId = 1;

    public List<Pizza> GetAll() => Pizzas;

    public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}
