using System.Runtime.Intrinsics.X86;
using contosopizza.Data;
using contosopizza.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace contosopizza.Service;

public class PizzaService
{
    static int nextId = 3;
    static public List<Pizza> Pizzas { get; }

    private readonly PizzaContext pContext;

    public PizzaService(PizzaContext context)
    {
        pContext = context;
    }
    /// <summary>
    /// gets all Pizzas
    /// </summary>
    public List<Pizza> GetAll() => pContext.Pizzas.AsNoTracking().ToList<Pizza>();



    /// <summary>
    /// get a pizza by id
    /// </summary>
    /// <param name="id"></param>
    public Pizza? GetById(int id) => pContext.Pizzas.Include(p => p.Toppings).Include(p => p.Sauce).AsNoTracking().ToList().SingleOrDefault(p => p.Id == id);


    /// <summary>
    /// Creates a new pizza
    /// </summary>
    /// <param name="pizza"></param>
    /// <returns>pizza</returns>
    public Pizza Create(Pizza pizza)
    {
        pContext.Add<Pizza>(pizza);
        pContext.SaveChanges();

        return pizza;
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
    public void UpdateSauce(int id, int sauceId)
    {
        Pizza? pizzaToUpdate = pContext.Pizzas.Find(id);
        Sauce? sauceToUpdate = pContext.Sauces.Find(sauceId);

        if (pizzaToUpdate is null || sauceToUpdate is null)
            throw new InvalidOperationException("Pizza or topping does not exist");

        pizzaToUpdate.Sauce = sauceToUpdate;
        pContext.SaveChanges();
    }

    /// <summary>
    /// Gets all the sauces
    /// </summary>
    /// <returns></returns>
    public List<Sauce> GetAllSauce() => pContext.Sauces.AsNoTracking().ToList<Sauce>();
    /// <summary>
    /// Adds a topping to pizza
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toppingId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddTopping(int id, int toppingId)
    {
        Pizza? pizzaToUpdated = pContext.Pizzas.Find(id);
        Topping? toppingToAdd = pContext.Toppings.Find(toppingId);

        if (pizzaToUpdated is null || toppingToAdd is null)
            throw new InvalidOperationException("Pizza or topping does not exist");

        if (pizzaToUpdated.Toppings is null)
            pizzaToUpdated.Toppings = new List<Topping>();

        pizzaToUpdated.Toppings.Add(toppingToAdd);

        pContext.SaveChanges();

    }


    /// <summary>
    /// deletes item by id
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void DeleteById(int id)
    {
        Pizza? pizzaToDelete = pContext.Pizzas.Find(id);
        if (pizzaToDelete is null)
            throw new InvalidOperationException("Pizza or topping does not exist");

        pContext.Remove(pizzaToDelete);
    }
}