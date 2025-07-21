namespace SampleGame
{
    public static class HealthUseCase
    {
        public static bool Exists(in IGameEntity entity)
        {
            return entity.GetHealth() > 0;
        }
    }
}