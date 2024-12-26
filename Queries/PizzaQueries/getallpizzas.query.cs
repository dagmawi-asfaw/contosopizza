using contosopizza.Models;
using MediatR;

namespace contosopizza.Queries.PizzaQuery;


public record GetAllPizzasQuery() : IRequest<IEnumerable<Pizza>>;