using abdp12.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace abdp12.Controllers;
[Route("[controller]")]
[ApiController]
public class TripsController :ControllerBase
{
    IDbService _dbService;
    public TripsController(IDbService service)
    {
        _dbService = service;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize=10)
    {
        if(page <= 0) page = 1;
        if(pageSize <= 0) pageSize = 10;
        return Ok(await _dbService.GetTrips(page, pageSize));
    }

    [HttpDelete("delete-client")]
    public async Task<IActionResult> Delete([FromQuery] int clientId)
    {
        var (code, message) = await _dbService.DeleteClient(clientId);

        return code switch
        {
            200 => Ok(message),
            400 => BadRequest(message),
            404 => NotFound(message),
            _ => StatusCode(500, "Unexpected error occurred")
        };
    }

}