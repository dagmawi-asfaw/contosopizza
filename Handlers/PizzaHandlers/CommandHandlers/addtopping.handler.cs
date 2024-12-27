using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var pizzaToUpdate = pizzaContext.Pizzas.Where(p => p.Id == request.pizzaId).SingleOrDefault();
        var toppingToAdd = pizzaContext.Toppings.Where(t => t.Id == request.toppingId).SingleOrDefault();
        if (pizzaToUpdate == null || toppingToAdd == null)
            return new NotFoundResult();
        pizzaContext.Toppings.Add(toppingToAdd);
        pizzaContext.SaveChanges();
        return new OkResult();
    }   
}