using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class DealDamageObserver : IInit, IEnable, IDisable
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
            var view = _viewContext.GetWorldView().GetView(target);
            _viewContext.GetAnimationQueue().Enqueue(new DealDamageAnimationCommand(view.transform));
        }
    }
}