using Microsoft.AspNetCore.Mvc;
using StudentsInventory.Models;

namespace StudentsInventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Success<T>(string message, T? data = default)
        {
            return Ok(new Response<T>(true, message, data));
        }

        protected IActionResult Success(string message)
        {
            return Ok(new Response(true, message));
        }

        protected IActionResult NotFound(string message)
        {
            return NotFound(new Response(false, message));
        }

        protected IActionResult BadRequest(string message, List<string>? errors = null)
        {
            return BadRequest(new Response(false, message, errors));
        }

        protected IActionResult InternalServerError(string message)
        {
            return StatusCode(500, new Response(false, message));
        }
    }
}