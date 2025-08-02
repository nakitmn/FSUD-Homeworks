using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public static class HealthUseCase
    {
        public static bool Exists(in IGameEntity entity)
        {
            return entity.GetHealth() > 0;
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
            entity.SetHealth(Mathf.Max(0, health - damage));
            return true;
        }
        
        public static bool Kill(IGameEntity entity)
        {
            if (Exists(entity) == false)
            {
                return false;
            }
            
            entity.SetHealth(0);
            return true;
        }
    }
}