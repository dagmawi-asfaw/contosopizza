using contosopizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Commands.PizzaCommands;


public record DeletePizzaCommand(int pizzaId): IRequest<IActionResult>;