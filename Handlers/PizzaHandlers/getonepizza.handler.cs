using contosopizza.Handlers.PizzaHandlers;
using contosopizza.Queries.PizzaQuery;
using contosopizza.Models;
using MediatR;
using contosopizza.Data;
using Microsoft.AspNetCore.Mvc;

public class GetOnePizzaHandler : IRequestHandler<GetOnePizzaQuery, IActionResult>
{
    private readonly PizzaContext pizzaContext;
    public GetOnePizzaHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }
    public async Task<IActionResult> Handle(GetOnePizzaQuery request, CancellationToken cancellationToken)
    {
        Pizza? pizza = pizzaContext.Pizzas.Where(pizza => pizza.Id == request.id).FirstOrDefault<Pizza>();
        if(pizza is null)
            return new NotFoundResult();
        return new OkObjectResult(pizza);    

    }}

 