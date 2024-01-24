namespace TetePizza.Data;
using TetePizza.Models;
using System.Data.SqlClient;

public class PizzaSqlRepository : IPizzaRepository
{
    private List<Pizza> Pizzas { get; } = new List<Pizza>();
    private int nextId = 1;
    private readonly string _connectionString;

    public PizzaSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Pizza> GetAll()
    {
        var pizzas = new List<Pizza>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "SELECT ID, Name, IsGlutenFree FROM Pizzas";
            var command = new SqlCommand(sqlString, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var pizza = new Pizza
                    {
                        Id = Convert.ToInt16(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        IsGlutenFree = (bool)reader["IsGlutenFree"]
                    };
                    pizzas.Add(pizza);
                }
            }

        }
        return pizzas;
    }

    public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}
