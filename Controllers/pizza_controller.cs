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
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza?> GetById(int id)
    {
        var pizza = PizzaService.GetById(id);
        if (pizza is null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Create(pizza);
        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        // return CreatedAtAction("create pizza", pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (pizza.Id != id)
            return BadRequest();

        var existingPizza = PizzaService.GetById(pizza.Id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.UpdatePizza(pizza);
        return NoContent();
    }


    public IActionResult AddTopping(int id, int toppingId)
    {
        var existingPizza = PizzaService.GetById(id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.AddTopping(id: id, toppingId: toppingId);
        return NoContent();

    }


    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var existingPizza = PizzaService.GetById(id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.UpdateSauce(id: id, sauceId: sauceId);
        return NoContent();
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingPizza = PizzaService.GetById(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.DeletePizza(id);

        return NoContent();
    }

}