using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Products from controller");
        }
    }
}