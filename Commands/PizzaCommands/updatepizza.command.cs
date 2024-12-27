using contosopizza.Models;
using MediatR;

namespace contosopizza.Commands.PizzaCommands;


public record UpdatePizzaCommand(Pizza pizza): IRequest;