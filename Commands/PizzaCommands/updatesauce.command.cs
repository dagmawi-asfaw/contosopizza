using contosopizza.Models;
using MediatR;

namespace contosopizza.Commands.PizzaCommands;


public record UpdateSauceCommand(int pizzaId, Sauce sauce): IRequest;