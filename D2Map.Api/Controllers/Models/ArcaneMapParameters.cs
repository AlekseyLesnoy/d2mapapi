using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using D2Map.Core.Models;

namespace D2Map.Api.Controllers.Models;

public class ArcaneMapParameters
{
    [Required]
    [FromQuery]
    public uint MapId { get; set; }

    [Required]
    [FromQuery] 
    public Difficulty? Difficulty { get; set; } = Core.Models.Difficulty.Hell;
}