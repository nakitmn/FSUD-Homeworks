using Atomic.Entities;

namespace Game.Core
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
        
        public static IGameEntity Spawn(IGameContext context, ScriptableEntityInstaller installer, GameBoardPosition position)
        {
            var entity = Spawn(context, installer);
            context.GetGameBoard().Set(entity, position);
            context.GetEventBus().InvokeSpawned(entity, position);
            return entity;
        }
    }
}