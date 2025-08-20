using Atomic.Entities;

namespace Game.Core
{
    public sealed class GameStartController : IEnable<IGameContext>
    {
        private readonly EntitySpawnConfig[] _entitySpawnConfigs;

        public GameStartController(EntitySpawnConfig[] entitySpawnConfigs)
        {
            _entitySpawnConfigs = entitySpawnConfigs;
        }
        
        public void Enable(IGameContext context)
        {
            foreach (var installer in _entitySpawnConfigs)
            {
                SpawnEntityUseCase.Spawn(context, installer.character, installer.position);
            }
                
            context.GetEventBus().InvokeStartPlayerTurn();
        }
    }
}