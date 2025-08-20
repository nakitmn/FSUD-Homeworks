using Atomic.Entities;
using Atomic.Events;

namespace Game.Core
{
    public sealed class StartEnemyTurnHandler : IInit<IGameContext>, IEnable, IDisable
    {
        private IEventBus _eventBus;
        private IGameContext _context;

        public void Init(IGameContext context)
        {
            _context = context;
            _eventBus = context.GetEventBus();
        }

        public void Enable(in IEntity entity)
        {
            _eventBus.SubscribeStartEnemyTurn(OnTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartEnemyTurn(OnTurnStart);
        }

        private void OnTurnStart()
        {
            CharacterTurnUseCase.ResetEnemies(_context);
            EnemyTurnUseCase.HandleEnemiesTurn(_context);
            EnemySpawnUseCase.TrySpawnEnemies(_context);
            _eventBus.InvokeEndEnemyTurn();
        }
    }
}