using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("states")]
public class StatesController : ControllerBase
{
    private readonly IStatesRepository statesRepository;

    public StatesController(IStatesRepository statesRepository)
    {
        this.statesRepository = statesRepository;
    }


    // GET /states
    [HttpGet("")]
    public IActionResult GetStates()
    {
        var states = statesRepository.GetStates();

        return Ok(states);
    }
}