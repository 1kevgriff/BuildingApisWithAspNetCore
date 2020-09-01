using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();

    [Route("/custom-error")]
    public IActionResult CustomError()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        
        return Problem(title: context.Error.Message);
    }
}