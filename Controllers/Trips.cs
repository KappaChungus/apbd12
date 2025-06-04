using abdp12.Services;
using Microsoft.AspNetCore.Mvc;

namespace abdp12.Controllers;
[Route("[controller]")]
[ApiController]
public class Trips :ControllerBase
{
    IDbService _dbService;
    public Trips(IDbService service)
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
}