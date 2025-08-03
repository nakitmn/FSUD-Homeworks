using Atomic.Entities;
using Atomic.Events;

namespace SampleGame
{
    public sealed class EndPlayerTurnHandler : IInit<IGameContext>, IEnable, IDisable
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
            _eventBus.SubscribeEndPlayerTurn(OnTurnEnd);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeEndPlayerTurn(OnTurnEnd);
        }

        private void OnTurnEnd()
        {
            _eventBus.InvokeStartEnemyTurn();
        }
    }
}