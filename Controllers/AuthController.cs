using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth/2.5")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Auth()
    {
        return Content("<AuthRes ret=\"Y\" code=\"100\" />", "application/xml");
    }
}