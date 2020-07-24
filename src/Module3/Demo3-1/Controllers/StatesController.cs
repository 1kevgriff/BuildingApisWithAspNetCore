using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("states")]
public class StatesController : ControllerBase
{
    public StatesController()
    {
    }

    // GET /states
    [HttpGet("")]
    public IActionResult GetStates([FromServices]IStatesRepository statesRepository)
    {
        // TODO: get states from repository
        var states = statesRepository.GetStates();

        return Ok(states);
    }
}