using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class LootUseCase
    {
        public static void DropLoot(IGameContext gameContext, Vector3 position, SceneEntity[] loot, float radius)
        {
            var pool = gameContext.GetEntityPool();
            
            foreach (var entity in loot)
            {
                var dropPosition = VectorUseCase.GetPositionInRadius(position, radius);
                pool.Rent(entity, dropPosition, Quaternion.identity);
            }
        }
    }
}