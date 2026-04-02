using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = new[]
        {
            new { id = 1, name = "Cocos" },
            new { id = 2, name = "Ananas" }
        };

        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = new { id, name = "Name" };
        return Ok(customer);
    }

    [HttpGet("{id}/reviews/{reviewId}")]
    public IActionResult GetById(int id, int reviewId)
    {
        var customer = new { id, name = "Name", reviewId };
        return Ok(customer);
    }
}
