namespace TetePizza.Bussines;
using TetePizza.Models;
using TetePizza.Data;

public class IngredientesServices : IIngredientesServices
{
    private IIngredientesRepository _repository;

    public IngredientesServices(IIngredientesRepository repository)
    {
        _repository = repository;
    }

    public List<Ingredientes> GetAll() => _repository.GetAll();

    public Ingredientes? Get(int id) => _repository.Get(id);

    public void Add(Ingredientes Ingredientes)
    {
        _repository.Add(Ingredientes);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public void Update(Ingredientes Ingredientes)
    {
        _repository.Update(Ingredientes);
    }
}