using contosopizza.Models;
using MediatR;

namespace contosopizza.Queries.PizzaQuery;

public record GetAllSaucesQuery() : IRequest<IEnumerable<Sauce>>;