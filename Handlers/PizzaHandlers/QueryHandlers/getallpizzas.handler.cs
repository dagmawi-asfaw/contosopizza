using contosopizza.Data;
using contosopizza.Models;
using contosopizza.Queries.PizzaQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Handlers.PizzaHandlers.QueryHandlers;


public class GetAllPizzasHandler : IRequestHandler<GetAllPizzasQuery, IEnumerable<Pizza>>
{
    private readonly PizzaContext pizzaContext;

    public GetAllPizzasHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }
    public async Task<IEnumerable<Pizza>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
    => pizzaContext.Pizzas.AsNoTracking().ToList<Pizza>();
}