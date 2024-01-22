using TetePizza.Models;
using TetePizza.Bussines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TetePizza.Api
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly IIngredientesServices _IngredientesServices;

        public IngredientesController(IIngredientesServices IngredientesServices)
        {
            _IngredientesServices = IngredientesServices;
        }

        [HttpGet]
        public ActionResult<List<Ingredientes>> GetAll() =>
            _IngredientesServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Ingredientes> Get(int id)
        {
            var Ingredientes = _IngredientesServices.Get(id);

            if (Ingredientes == null)
                return NotFound();

            return Ingredientes;
        }

        [HttpPost]
        public IActionResult Create(Ingredientes Ingredientes)
        {
            _IngredientesServices.Add(Ingredientes);
            return CreatedAtAction(nameof(Get), new { id = Ingredientes.Id }, Ingredientes);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ingredientes Ingredientes)
        {
            if (id != Ingredientes.Id)
                return BadRequest();

            var existingIngredientes = _IngredientesServices.Get(id);
            if (existingIngredientes is null)
                return NotFound();

            _IngredientesServices.Update(Ingredientes);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Ingredientes = _IngredientesServices.Get(id);

            if (Ingredientes is null)
                return NotFound();

            _IngredientesServices.Delete(id);

            return NoContent();
        }
    }
}
