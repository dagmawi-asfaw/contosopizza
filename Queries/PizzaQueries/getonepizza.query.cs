using contosopizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Queries.PizzaQuery;

public record GetOnePizzaQuery(int id): IRequest<IActionResult>;