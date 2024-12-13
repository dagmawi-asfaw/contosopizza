using contosopizza.Models;
using contosopizza.Service;
using Microsoft.AspNetCore.Mvc;

namespace contosopizza.Controllers;

[ApiController]
[Route("[Controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }


    [HttpGet]
    public ActionResult<List<Pizza>> Get() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza?> Get(int id)
    {
        var pizza = PizzaService.GetOne(id);
        if (pizza is null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        // return CreatedAtAction("create pizza", pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (pizza.Id != id)
            return BadRequest();

        var existingPizza = PizzaService.GetOne(pizza.Id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.Update(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingPizza = PizzaService.GetOne(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }

}