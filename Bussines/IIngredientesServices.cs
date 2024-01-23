namespace TetePizza.Bussines;
using TetePizza.Models;

public interface IIngredientesServices
{
    List<Ingredientes> GetAll();
    Ingredientes Get(int id);
    void Add(Ingredientes Ingredientes);
    void Delete(int id);

    void Update(Ingredientes Ingredientes);

    List<Ingredientes> GetPizzaIngredientes(int pizzaId);

    void AddIngrediente(int pizzaId, int id);

}