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
    public ActionResult<bool> Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return true;
    }

    [HttpPut]
    public ActionResult<bool> Update(Pizza pizza)
    {
        PizzaService.Update(pizza);
        return true;
    }

    [HttpDelete]
    public ActionResult<bool> Delete(int id)
    {
        PizzaService.Delete(id);
        return true;
    }

}