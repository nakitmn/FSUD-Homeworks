using Atomic.Entities;
using Atomic.Events;

namespace SampleGame
{
    public sealed class EndTurnHandler : IInit<IGameContext>, IEnable, IDisable
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
            _eventBus.SubscribeEndTurn(OnTurnEnd);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeEndTurn(OnTurnEnd);
        }

        private void OnTurnEnd()
        {
            _context.GetSelectedCharacter().Value = null;
            EnemyUseCase.HandleEnemiesTurn(_context);
            EnemyUseCase.TrySpawnEnemies(_context);
            _context.GetTurn().Value++;

            GameStateUseCase.UpdateCurrentState(_context);
            if (_context.GetCurrentState().Value != GameState.Running)
            {
                return;
            }

            _eventBus.InvokeStartTurn();
        }
    }
}