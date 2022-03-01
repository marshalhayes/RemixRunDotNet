using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello, world from Remix & .NET!");
    }
}