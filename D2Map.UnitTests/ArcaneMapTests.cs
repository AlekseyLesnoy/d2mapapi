using D2Map.Core.Models;
using FluentAssertions;
using NUnit.Framework;

namespace D2Map.UnitTests;

public class ArcaneMapTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindSummonerDirection_PredefinedCoordinates_ReturnsSouth()
    {
        var map = new ArcaneMap()
        {
            WaypointInfo = new PointX(25449, 5449),
            SummonerInfo = new PointX(25440, 5870)
        };

        map.FindSummonerDirection().Should().Be(Direction.South);
    }

    [Test]
    public void FindSummonerDirection_PredefinedCoordinates_ReturnsEast()
    {
        var map = new ArcaneMap()
        {
            WaypointInfo = new PointX(25449, 5449),
            SummonerInfo = new PointX(25875, 5440)
        };

        map.FindSummonerDirection().Should().Be(Direction.East);
    }

    [Test]
    public void FindSummonerDirection_PredefinedCoordinates_ReturnsNorth()
    {
        var map = new ArcaneMap()
        {
            WaypointInfo = new PointX(25449, 5449),
            SummonerInfo = new PointX(25440, 5020)
        };

        map.FindSummonerDirection().Should().Be(Direction.North);
    }
}