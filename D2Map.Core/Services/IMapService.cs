using D2Map.Core.Models;

namespace D2Map.Core.Services
{
    public interface IMapService
    {
        CollisionMap GetCollisionMap(uint mapId, Difficulty difficulty, Area area);
        ArcaneMap GetArcaneMap(uint mapId, Difficulty difficulty);
    }
}
