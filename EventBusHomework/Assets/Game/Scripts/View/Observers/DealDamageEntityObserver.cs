using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class DealDamageEntityObserver : IInit, IEnable, IDisable
    {
        private GameContext _gameContext;
        private ViewContext _viewContext;

        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
            _viewContext = ViewContext.Instance;
        }

        public void Enable(in IEntity entity)
        {
            _gameContext.GetEventBus().SubscribeDamaged(OnDamaged);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeDamaged(OnDamaged);
        }

        private void OnDamaged(IGameEntity target, int damage)
        {
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new CharacterDealDamageAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, target).transform, 
                    HealthUseCase.GetNormalizedHealth(target))
            );
        }
    }
}