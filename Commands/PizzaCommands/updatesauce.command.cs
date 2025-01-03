using contosopizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Commands.PizzaCommands;


public record UpdateSauceCommand(int pizzaId, int sauceId): IRequest<IActionResult>;