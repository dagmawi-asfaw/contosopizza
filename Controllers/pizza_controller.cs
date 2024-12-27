using contosopizza.Commands.PizzaCommands;
using contosopizza.Models;
using contosopizza.Queries.PizzaQuery;
using contosopizza.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Controllers;

[ApiController]
[Route("[Controller]")]
public class PizzaController : ControllerBase
{

    private readonly ISender _sender;
    // private readonly IPublisher _publisher;
    public PizzaController(ISender sender)
    {
        _sender = sender;
        //     _publisher = publisher;
    }

    /// <summary>
    /// Gets all pizzas
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<Pizza>), 200)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pizza>>> GetAll()
    {
        var pizzas = await _sender.Send(new GetAllPizzasQuery());
        return new OkObjectResult(pizzas);
    }

    /// <summary>
    /// Gets one pizza by id
    /// </summary>
    /// <param name="id"/>
    [Produces("application/json")]
    [ProducesResponseType(typeof(BadRequestResult), 200)]
    [ProducesResponseType(typeof(Pizza), 200)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var result = await _sender.Send(new GetOnePizzaQuery(id));
        return result;
    }
    /// <summary>
    /// Creates a new pizza
    /// </summary>
    /// <param name="pizza"/>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Pizza), 200)]
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {

        var result = _sender.Send(new AddPizzaCommand(pizza));

        return Ok(result);

    }

    /// <summary>
    /// Updates a pizza by id
    /// </summary>
    /// <param name="pizza"/>
    [Produces("application/json")]
    [HttpPut("{id}")]
    public IActionResult Update(Pizza pizza)
    {
        var result = _sender.Send(new UpdatePizzaCommand(pizza));

        return Ok(result);

    }

    /// <summary>
    /// Adds a topping to a pizza
    /// </summary>
    /// <param name="id"/>
    /// <param name="toppingId"/>
    [Produces("application/json")]
    [HttpPut("{id}/topping/{toppingId}")]
    public async Task<IActionResult> AddToppingToPizza(int id, int toppingId)
    {
        var result = await _sender.Send(new AddToppingToPizzaCommand(id, toppingId));

        return result;

    }

    /// <summary>
    /// Updates the sauce on a pizza
    /// </summary>
    /// <param name="id"/>
    /// <param name="sauceId"/>
    [Produces("application/json")]
    [HttpPut("{id}/sauce/{sauceId}")]
    public async Task<IActionResult> UpdateSauce(int id, int sauceId)
    {

        var result = await _sender.Send(new UpdateSauceCommand(id, sauceId));
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Gets all sauces of a pizza
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<Sauce>), 200)]
    [HttpGet("/sauce")]
    public ActionResult<List<Sauce>> GetAllSauce()
    {
        var result = _sender.Send(new GetAllSaucesQuery());
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Deletes a pizza
    /// </summary>
    /// <param name="id"/>
    [Produces("application/json")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePizza(int id) => await _sender.Send(new DeletePizzaCommand(id));

}