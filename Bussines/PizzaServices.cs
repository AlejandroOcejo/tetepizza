namespace TetePizza.Bussines;
using TetePizza.Models;
using TetePizza.Data;
using System.Collections.Generic;

public class PizzaServices : IPizzaServices
{
    private IPizzaRepository _pizzaRepository;
    private IIngredientesRepository _ingredientesRepository;

    public PizzaServices(IPizzaRepository pizzaRepository, IIngredientesRepository ingredientesRepository)
    {
        _pizzaRepository = pizzaRepository;
        _ingredientesRepository = ingredientesRepository;
    }

    public List<Pizza> GetAll()
    {
        var pizzas = _pizzaRepository.GetAll();
        foreach (var pizza in pizzas)
        {
            pizza.Ingredientes = _ingredientesRepository.GetPizzaIngredientes(pizza.Id);
        }
        return pizzas;
    }


    public Pizza? Get(int id)
    {
        var pizza = _pizzaRepository.Get(id);
        if (pizza != null)
        {
            pizza.Ingredientes = _ingredientesRepository.GetPizzaIngredientes(id);
        }
        return pizza;
    }

    public void Add(Pizza pizza)
    {
        _pizzaRepository.Add(pizza);
    }

    public void Delete(int id)
    {
        _pizzaRepository.Delete(id);
    }

    public void Update(Pizza pizza)
    {
        _pizzaRepository.Update(pizza);
    }

}
