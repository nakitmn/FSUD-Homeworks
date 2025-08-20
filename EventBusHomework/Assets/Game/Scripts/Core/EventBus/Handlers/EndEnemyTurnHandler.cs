using Atomic.Entities;
using Atomic.Events;

namespace Game.Core
{
    public sealed class EndEnemyTurnHandler : IInit<IGameContext>, IEnable, IDisable
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
            _eventBus.SubscribeEndEnemyTurn(OnTurnEnd);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeEndEnemyTurn(OnTurnEnd);
        }

        private void OnTurnEnd()
        {
            GameStateUseCase.UpdateCurrentState(_context);
            if (_context.GetCurrentState().Value != GameState.Running)
            {
                return;
            }
            
            _context.GetTurn().Value++;
            _eventBus.InvokeStartPlayerTurn();
        }
    }
}