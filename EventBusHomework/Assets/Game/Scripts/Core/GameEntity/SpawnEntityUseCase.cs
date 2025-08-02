using Atomic.Entities;

namespace SampleGame
{
    public static class SpawnEntityUseCase
    {
        public static IGameEntity Spawn(IGameContext context, IEntityInstaller installer)
        {
            var gameEntity = new GameEntity();
            installer.Install(gameEntity);
            context.GetEntityWorld().Add(gameEntity);
            return gameEntity;
        }
    }
}