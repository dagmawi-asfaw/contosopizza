using contosopizza.Models;
using MediatR;

namespace contosopizza.Commands.PizzaCommands;


public record AddToppingCommand(int pizzaId,Topping topping): IRequest;