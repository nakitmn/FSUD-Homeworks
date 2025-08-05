using Atomic.Entities;

namespace SampleGame
{
    public sealed class GameRunController : IEnable<IGameContext>
    {
        private readonly EntitySpawnConfig[] _entitySpawnConfigs;

        public GameRunController(EntitySpawnConfig[] entitySpawnConfigs)
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