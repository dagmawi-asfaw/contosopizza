using contosopizza.Data;
using contosopizza.Models;
using contosopizza.Queries.PizzaQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Handlers.PizzaHandlers;


public class PizzaHandler : IRequestHandler<GetAllPizzasQuery, IEnumerable<Pizza>>
{
    private readonly PizzaContext pContext;

    public PizzaHandler(PizzaContext context)
    {
        this.pContext = context;
    }
    public async Task<IEnumerable<Pizza>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
    {
        return pContext.Pizzas.AsNoTracking().ToList<Pizza>();

    }
}