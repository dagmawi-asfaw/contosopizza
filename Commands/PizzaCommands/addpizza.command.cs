using contosopizza.Models;
using MediatR;

namespace contosopizza.Commands.PizzaCommands;


public record AddPizzaCommand(Pizza pizza): IRequest;