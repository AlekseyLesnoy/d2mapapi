using System;
using D2Map.Core.Extensions;

namespace D2Map.Core.Models;

public class ArcaneMap
{
    public PointX SummonerInfo { get; set; }
    public PointX WaypointInfo { get; set; }

    public Direction FindSummonerDirection()
    {
        var angle = SummonerInfo.Subtract(WaypointInfo).Angle() * 180 / Math.PI;

        var direction = angle switch
        {
            >= -135 and < -45 => Direction.North,
            >= -45 and < 45 => Direction.East,
            >= 45 and <= 135 => Direction.South,
            _ => Direction.West
        };

        return direction;
    }
}

public static class DirectionExtensions
{
    public static SummonerDirection MapToApi(this Direction direction) => direction switch
    {
        Direction.North => new SummonerDirection {Direction = "N"},
        Direction.South => new SummonerDirection {Direction = "S"},
        Direction.West => new SummonerDirection {Direction = "W"},
        Direction.East => new SummonerDirection {Direction = "E"},
        _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Direction value not expected: {direction}"),
    };
}

public class SummonerDirection
{
    public string Direction { get; set; }
}