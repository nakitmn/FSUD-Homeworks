using Atomic.Entities;

namespace SampleGame
{
    public static class SpawnEntityUseCase
    {
        public static IGameEntity Spawn(IGameContext context, ScriptableEntityInstaller installer)
        {
            var gameEntity = new GameEntity(installer.name);
            installer.Install(gameEntity);
            context.GetEntityWorld().Add(gameEntity);
            return gameEntity;
        }
    }
}