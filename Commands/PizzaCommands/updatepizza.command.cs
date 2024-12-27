using contosopizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Commands.PizzaCommands;


public record UpdatePizzaCommand(Pizza pizza): IRequest<IActionResult>;