using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = new[] { "Order 1", "Order 2" };
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = new { id, namer = "Order" };
        return Ok(order);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Order order)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, order);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Order order)
    {
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
