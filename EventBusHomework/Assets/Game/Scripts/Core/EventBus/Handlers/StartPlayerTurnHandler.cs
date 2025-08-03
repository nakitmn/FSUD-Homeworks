using Atomic.Entities;
using Atomic.Events;

namespace SampleGame
{
    public sealed class StartPlayerTurnHandler : IInit<IGameContext>, IEnable, IDisable
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
            _eventBus.SubscribeStartPlayerTurn(OnTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartPlayerTurn(OnTurnStart);
        }

        private void OnTurnStart()
        {
            CharacterTurnUseCase.ResetCharacters(_context);
            CharacterTurnUseCase.ResetEnemies(_context);
        }
    }
}