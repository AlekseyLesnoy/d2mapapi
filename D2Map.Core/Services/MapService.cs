using D2Map.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace D2Map.Core.Services
{
    public class MapService : IMapService
    {
        private readonly IMemoryCache _cache;
        private static object syncObject = new object();
        public MapService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public CollisionMap GetCollisionMap(uint mapId, Difficulty difficulty, Area area)
        {
            var session = _cache.GetOrCreate(Tuple.Create("map", mapId, difficulty), (cacheEntry) =>
            {
                cacheEntry.RegisterPostEvictionCallback(DeleteSession);
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return new Session(mapId, difficulty);
            });
            lock (syncObject)
            {
                return session.GetMap(area);
            }
        }

        public ArcaneMap GetArcaneMap(uint mapId, Difficulty difficulty)
        {
            var map = GetCollisionMap(mapId, difficulty, Area.ArcaneSanctuary);
            var arcaneMap = new ArcaneMap()
            {
                SummonerInfo = map.Npcs[((int)Npc.Summoner).ToString()].First().ToPointX(),
                WaypointInfo = map.Objects["402"].First().ToPointX()
            };
            
            return arcaneMap;
        }

        private void DeleteSession(object key, object value, EvictionReason reason, object state)
        {
            var item = value as IDisposable;
            if (item != null)
                item.Dispose();
        }
    }
}
