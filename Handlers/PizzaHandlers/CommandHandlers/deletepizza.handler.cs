using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Handlers.PizzaHandlers.CommandHandlers;

public class DeletePizzaHandler : IRequestHandler<DeletePizzaCommand, IActionResult>
{
    private readonly PizzaContext pizzaContext;

    public DeletePizzaHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }

    public async Task<IActionResult> Handle(DeletePizzaCommand request, CancellationToken cancellationToken)
    {
        var pizzaToDelete = pizzaContext.Pizzas.Where(p => p.Id == request.pizzaId).SingleOrDefault();
        if (pizzaToDelete == null)
            return new NotFoundResult();
        pizzaContext.Pizzas.Remove(pizzaToDelete);
        pizzaContext.SaveChanges();
        return new OkResult();
    }



}