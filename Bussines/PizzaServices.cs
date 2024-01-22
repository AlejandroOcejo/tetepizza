namespace TetePizza.Bussines;
using TetePizza.Models;
using TetePizza.Data;

public class PizzaServices : IPizzaServices
{
    private IPizzaRepository _repository;

    public PizzaServices(IPizzaRepository repository)
    {
        _repository = repository;
    }

    public List<Pizza> GetAll() => _repository.GetAll();

    public Pizza? Get(int id) => _repository.Get(id);

    public void Add(Pizza pizza)
    {
        _repository.Add(pizza);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public void Update(Pizza pizza)
    {
        _repository.Update(pizza);
    }
}