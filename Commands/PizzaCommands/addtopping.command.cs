using contosopizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Commands.PizzaCommands;


public record AddToppingToPizzaCommand(int pizzaId,int toppingId): IRequest<IActionResult>;