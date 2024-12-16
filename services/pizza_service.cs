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

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? GetById(int id) => Pizzas.Where<Pizza>(pizza => pizza.Id.Equals(id)).FirstOrDefault();


    public static void Create(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void UpdatePizza(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;

    }

    public static void UpdateSauce(int id, int sauceId)
    {
        throw new NotImplementedException();
    }

    public static void AddTopping(int id, int toppingId)
    {
        throw new NotImplementedException();
    }

    public static void DeletePizza(int id)
    {
        var pizza = GetById(id);
        if (pizza != null)
            Pizzas.Remove(pizza);
    }

    public static void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}