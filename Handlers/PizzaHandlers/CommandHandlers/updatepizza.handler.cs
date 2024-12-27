using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Handlers.PizzaHandlers.CommandHandlers;

public class UpdatePizzaHandler : IRequestHandler<UpdatePizzaCommand, IActionResult>
{
    private readonly PizzaContext pizzaContext;

    public UpdatePizzaHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }

    public async Task<IActionResult> Handle(UpdatePizzaCommand request, CancellationToken cancellationToken)
    {
        var pizzaToUpdate = pizzaContext.Pizzas.Where(p => p.Id == request.pizza.Id).SingleOrDefault();
        if (pizzaToUpdate == null)
            return new NotFoundResult();

        pizzaContext.Pizzas.Remove(pizzaToUpdate);
        pizzaContext.Pizzas.Add(request.pizza);
        pizzaContext.SaveChanges();
        return new OkObjectResult(request.pizza);

    }
}