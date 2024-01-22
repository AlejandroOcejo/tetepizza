using TetePizza.Models;
using TetePizza.Bussines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TetePizza.Api
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaServices;

        public PizzaController(IPizzaServices pizzaServices)
        {
            _pizzaServices = pizzaServices;
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
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
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
    }
}
