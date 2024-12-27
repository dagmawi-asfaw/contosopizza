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
    private readonly PizzaService service;

    private readonly ISender _sender;
    public PizzaController(PizzaService pizzaService, ISender sender)
    {
        service = pizzaService;
        _sender = sender;
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
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        service.Create(pizza);
        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        // return CreatedAtAction("create pizza", pizza);
    }

    /// <summary>
    /// Updates a pizza by id
    /// </summary>
    /// <param name="id"/>
    /// <param name="pizza"/>
    [Produces("application/json")]
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (pizza.Id != id)
            return BadRequest();

        var existingPizza = service.GetById(pizza.Id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.UpdatePizza(pizza);
        return NoContent();
    }

    /// <summary>
    /// Adds a topping to a pizza
    /// </summary>
    /// <param name="id"/>
    /// <param name="toppingId"/>
    [Produces("application/json")]
    [HttpPut("{id}/topping/{toppingId}")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var existingPizza = service.GetById(id);
        if (existingPizza is null)
            return NotFound();
        //   PizzaService.AddTopping(id: id, toppingId: toppingId);
        return NoContent();

    }

    /// <summary>
    /// Updates the sauce on a pizza
    /// </summary>
    /// <param name="id"/>
    /// <param name="sauceId"/>
    [Produces("application/json")]
    [HttpPut("{id}/sauce/{sauceId}")]
    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var existingPizza = service.GetById(id);
        if (existingPizza is null)
            return NotFound();
        service.UpdateSauce(id: id, sauceId: sauceId);
        return NoContent();
    }

    /// <summary>
    /// Gets all sauces of a pizza
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<Sauce>), 200)]
    [HttpGet("/sauce")]
    public ActionResult<List<Sauce>> GetAllSauce() => service.GetAllSauce();

    /// <summary>
    /// Deletes a pizza
    /// </summary>
    /// <param name="id"/>
    [Produces("application/json")]
    [HttpDelete("{id}")]
    public IActionResult DeletePizza(int id)
    {
        var existingPizza = service.GetById(id);
        if (existingPizza is null)
            return NotFound();

        service.DeleteById(id);

        return NoContent();
    }

}