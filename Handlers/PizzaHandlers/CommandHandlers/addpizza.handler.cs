using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Handlers.PizzaHandlers.CommandHandlers;

public class AddPizzaHandler : IRequestHandler<AddPizzaCommand,IActionResult>
{
    private readonly PizzaContext pizzaContext;

    public AddPizzaHandler(PizzaContext context){
        this.pizzaContext = context;
    }
     

   async Task<IActionResult> IRequestHandler<AddPizzaCommand, IActionResult>.Handle(AddPizzaCommand request, CancellationToken cancellationToken)
    {
        pizzaContext.Pizzas.Add(request.pizza);
        pizzaContext.SaveChanges();

        return new OkObjectResult(request.pizza);
    }
}