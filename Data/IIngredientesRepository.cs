namespace TetePizza.Data;
using TetePizza.Models;

public interface IIngredientesRepository
{

    List<Ingredientes> GetAll();
    Ingredientes Get(int id);
    void Add(Ingredientes Ingredientes);
    void Delete(int id);

    void Update(Ingredientes Ingredientes);

    List<Ingredientes> GetPizzaIngredientes(int id);

    void AddIngrediente(int pizzaId, int ingredienteId);
}
