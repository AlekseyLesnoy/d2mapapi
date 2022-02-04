using D2Map.Api.Controllers.Models;
using D2Map.Core.Models;
using D2Map.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace D2Map.Api.Controllers;

[ApiController]
[Route("/arcane")]
public class ArcaneApiController : ControllerBase
{
    private readonly IMapService _mapService;

    public ArcaneApiController(IMapService mapService)
    {
        _mapService = mapService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] ArcaneMapParameters parameters)
    {
        var arcane = _mapService.GetArcaneMap(parameters.MapId, parameters.Difficulty.GetValueOrDefault());
        return Ok(arcane.FindSummonerDirection().MapToApi());
    }
}