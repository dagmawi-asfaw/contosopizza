using contosopizza.Data;
using contosopizza.Models;

namespace ContosoPizza.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {

            if (context.Pizzas.Any()
                && context.Toppings.Any()
                && context.Sauces.Any())
            {
                return;   // DB has been seeded
            }

            var pepperoniTopping = new Topping { Id = 1, Name = "Pepperoni", Calories = 130 };
            var sausageTopping = new Topping { Id = 2, Name = "Sausage", Calories = 100 };
            var hamTopping = new Topping { Id = 3, Name = "Ham", Calories = 70 };
            var chickenTopping = new Topping { Id = 4, Name = "Chicken", Calories = 50 };
            var pineappleTopping = new Topping { Id = 5, Name = "Pineapple", Calories = 75 };

            var tomatoSauce = new Sauce { Id = 1, Name = "Tomato", IsVegan = true };
            var alfredoSauce = new Sauce { Id = 2, Name = "Alfredo", IsVegan = false };

            var toppings = new Topping[]{
                pepperoniTopping,
                sausageTopping,
                hamTopping,
                chickenTopping,
                pineappleTopping,
            };

            var sauces = new Sauce[]{
                tomatoSauce,
                alfredoSauce,
            };


            var pizzas = new Pizza[]
            {
                new Pizza
                    {
                        Name = "Meat Lovers",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pepperoniTopping,
                                sausageTopping,
                                hamTopping,
                                chickenTopping
                            }
                    },
                new Pizza
                    {
                        Name = "Hawaiian",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pineappleTopping,
                                hamTopping
                            }
                    },
                new Pizza
                    {
                        Name="Alfredo Chicken",
                        Sauce = alfredoSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            }
                        }
            };

            context.Toppings.AddRange(toppings);
            context.Sauces.AddRange(sauces);
            context.Pizzas.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}