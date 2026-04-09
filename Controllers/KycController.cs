using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("kyc/2.5")]
public class KycController : ControllerBase
{
    private readonly IKycService _service;

    public KycController(IKycService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var xml = await new StreamReader(Request.Body).ReadToEndAsync();

        var scenario = Request.Headers["X-Mock-Scenario"].FirstOrDefault();

        var response = _service.Process(xml, scenario);

        return Content(response, "application/xml");
    }
}