using contosopizza.Models;

namespace contosopizza.Service;

public static class PizzaService
{
    static int nextId = 3;
    static public List<Pizza> Pizzas { get; }

    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian",},
            new Pizza { Id = 2, Name = "Veggie", }
        };
    }
    /// <summary>
    /// gets all Pizzas
    /// </summary>
    public static List<Pizza> GetAll() => Pizzas;
    /// <summary>
    /// get a pizza by id
    /// </summary>
    /// <param name="id"></param>
    public static Pizza? GetById(int id) => Pizzas.Where<Pizza>(pizza => pizza.Id.Equals(id)).FirstOrDefault();

    /// <summary>
    /// Creates a new pizza
    /// </summary>
    /// <param name="pizza"></param>
    public static void Create(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    /// <summary>
    /// Updates a pizza
    /// </summary>
    /// <param name="pizza"></param>
    public static void UpdatePizza(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;

    }

    /// <summary>
    /// Updates a sauce on a pizza
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sauceId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void UpdateSauce(int id, int sauceId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a topping to pizza
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toppingId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void AddTopping(int id, int toppingId)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Deletes a pizza by id
    /// </summary>
    /// <param name="id"></param>
    public static void DeletePizza(int id)
    {
        var pizza = GetById(id);
        if (pizza != null)
            Pizzas.Remove(pizza);
    }

    /// <summary>
    /// deletes item by id
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}