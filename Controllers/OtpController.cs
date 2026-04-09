using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("otp/2.5")]
public class OtpController : ControllerBase
{
    [HttpPost]
    public IActionResult SendOtp()
    {
        return Content("<OtpRes ret=\"Y\" code=\"100\" />", "application/xml");
    }
}