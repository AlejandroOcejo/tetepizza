namespace TetePizza.Bussines
{
    using System.Collections.Generic;
    using TetePizza.Models;
    using TetePizza.Data;

    public class IngredientesServices : IIngredientesServices
    {
        private IIngredientesRepository _repository;

        public IngredientesServices(IIngredientesRepository repository)
        {
            _repository = repository;
        }

        public List<Ingredientes> GetAll()
        {
            return _repository.GetAll();
        }

        public Ingredientes Get(int ingredienteId)
        {
            return _repository.Get(ingredienteId);
        }

        public void Add(Ingredientes ingredientes)
        {
            _repository.Add(ingredientes);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Ingredientes ingredientes)
        {
            _repository.Update(ingredientes);
        }

        public List<Ingredientes> GetPizzaIngredientes(int pizzaId)
        {
            return _repository.GetPizzaIngredientes(pizzaId);
        }

        public void AddIngrediente(int pizzaId, int ingredienteId)
        {
            _repository.AddIngrediente(pizzaId, ingredienteId);
        }
    }
}
