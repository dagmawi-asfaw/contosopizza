using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Handlers.PizzaHandlers.CommandHandlers;

public class AddToppingToPizzaHandler : IRequestHandler<AddToppingToPizzaCommand, IActionResult>
{
    private readonly PizzaContext pizzaContext;

    public AddToppingToPizzaHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }
    public async Task<IActionResult> Handle(AddToppingToPizzaCommand request, CancellationToken cancellationToken)
    {
        var pizzaToUpdate = pizzaContext.Pizzas.Include("Toppings").FirstOrDefault(p => p.Id == request.pizzaId);
        var toppingToAdd = pizzaContext.Toppings.FirstOrDefault(t => t.Id == request.toppingId);

        if (pizzaToUpdate == null || toppingToAdd == null)
            return new NotFoundResult();
        var toppingExists = pizzaToUpdate.Toppings.FirstOrDefault(t => t.Id == toppingToAdd.Id);
        if (toppingExists is null)
        {
            pizzaToUpdate.Toppings.Add(toppingToAdd);
            pizzaContext.SaveChanges();
            return new OkObjectResult(pizzaToUpdate);
        }
        return new OkObjectResult("Topping already exists on pizza");
    }
}