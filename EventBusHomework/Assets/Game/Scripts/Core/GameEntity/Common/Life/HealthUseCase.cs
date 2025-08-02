using System.Collections.Generic;

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
    }
}