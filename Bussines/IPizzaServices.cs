namespace TetePizza.Bussines;
using TetePizza.Models;

public interface IPizzaServices
{
    List<Pizza> GetAll();
    Pizza Get(int id);
    void Add(Pizza pizza);
    void Delete(int id);

    void Update(Pizza pizza);

}