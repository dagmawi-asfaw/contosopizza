using contosopizza.Data;
using contosopizza.Models;
using contosopizza.Queries.PizzaQuery;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Handlers.PizzaHandlers;

public class GetAllSaucesHandler : IRequestHandler<GetAllSaucesQuery, IEnumerable<Sauce>>
{
    private readonly PizzaContext pizzaContext;

    public GetAllSaucesHandler(PizzaContext context)
    {
        this.pizzaContext = context;
    }
    public async Task<IEnumerable<Sauce>> Handle(GetAllSaucesQuery request, CancellationToken cancellationToken)
    => pizzaContext.Sauces.AsNoTracking().ToList<Sauce>();
}