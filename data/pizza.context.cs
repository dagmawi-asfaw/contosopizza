using contosopizza.Models;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Data;

/// <summary>
/// Pizza context
/// </summary>
/// <param name="options"></param>
public class PizzaContext(DbContextOptions<PizzaContext> options) : DbContext(options)
{

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
    public DbSet<Topping> Toppings => Set<Topping>();
}