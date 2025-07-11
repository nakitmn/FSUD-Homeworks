using Atomic.Entities;

namespace SampleGame
{
    public static class HealthUseCase
    {
        public static bool IsAlive(in IGameEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }
    }
}