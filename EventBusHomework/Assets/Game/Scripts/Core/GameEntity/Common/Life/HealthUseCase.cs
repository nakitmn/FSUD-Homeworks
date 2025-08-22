using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public static class HealthUseCase
    {
        public static bool Exists(IGameEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }

        public static bool HasAliveEntities(IEnumerable<IGameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (Exists(entity))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DealDamage(IGameEntity entity, int damage)
        {
            if (Exists(entity) == false)
            {
                return false;
            }

            var health = entity.GetHealth();
            health.Value = Mathf.Max(0, health.Value - damage);
            return true;
        }
        
        public static bool Kill(IGameEntity entity)
        {
            if (Exists(entity) == false)
            {
                return false;
            }

            entity.GetHealth().Value = 0;
            return true;
        }

        public static float GetNormalizedHealth(IGameEntity entity)
        {
            return (float) entity.GetHealth().Value / entity.GetMaxHealth().Value;
        }
    }
}