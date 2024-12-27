using contosopizza.Commands.PizzaCommands;
using contosopizza.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Handlers.PizzaHandlers.CommandHandlers;

public class UpdateSauceHandler : IRequestHandler<UpdateSauceCommand, IActionResult>
{
    private readonly PizzaContext pizzaContext;

    public UpdateSauceHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }
    public async Task<IActionResult> Handle(UpdateSauceCommand request, CancellationToken cancellationToken)
    {
        var pizzaToUpdate = pizzaContext.Pizzas.Where(p => p.Id == request.pizzaId).SingleOrDefault();
        var sauceToUpdate = pizzaContext.Sauces.Where(s => s.Id == request.sauceId).SingleOrDefault();
        if (pizzaToUpdate == null || sauceToUpdate == null)
            return new NotFoundResult();

        pizzaToUpdate.Sauce = sauceToUpdate;
        pizzaContext.SaveChanges();
        return new OkObjectResult(pizzaToUpdate);
    }
}