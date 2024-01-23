namespace TetePizza.Api;
using TetePizza.Models;
using TetePizza.Bussines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaServices _pizzaServices;
    private readonly IIngredientesServices _ingredientesServices;

    public PizzaController(IPizzaServices pizzaServices, IIngredientesServices ingredientesServices)
    {
        _pizzaServices = pizzaServices;
        _ingredientesServices = ingredientesServices;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        _pizzaServices.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _pizzaServices.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }


    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _pizzaServices.Add(pizza);

        if (pizza.Id > 0)
        {
            foreach (var ingrediente in pizza.Ingredientes)
            {
                _ingredientesServices.Add(ingrediente);
            }
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _pizzaServices.Get(id);
        if (existingPizza is null)
            return NotFound();

        _pizzaServices.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaServices.Get(id);

        if (pizza is null)
            return NotFound();

        _pizzaServices.Delete(id);

        return NoContent();
    }

    [HttpGet("{id}/ingredientes")]
    public ActionResult<List<Ingredientes>> GetAllIngredients(int id)
    {
        var ingredientes = _ingredientesServices.GetPizzaIngredientes(id);

        if (ingredientes == null || ingredientes.Count == 0)
            return NotFound();

        return ingredientes;
    }

    [HttpPost("{pizzaId}/ingrediente/{id}")]
    public ActionResult<Ingredientes> AddIngrediente(int pizzaId, int id)
    {
        if (pizzaId > 0 && id > 0)
        {
            _ingredientesServices.AddIngrediente(pizzaId, id);
            return NoContent();
        }
        return NotFound();

    }

}