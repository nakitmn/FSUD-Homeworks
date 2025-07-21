using System;
using Atomic.Entities;
using Atomic.Events;

namespace SampleGame
{
    public sealed class StartTurnHandler : IInit<IGameContext>, IEnable, IDisable
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
            _eventBus.SubscribeStartTurn(OnTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartTurn(OnTurnStart);
        }

        private void OnTurnStart()
        {
            CharacterTurnUseCase.ResetCharacters(_context);
            _context.GetTurn().Value++;
        }
        
    }
}