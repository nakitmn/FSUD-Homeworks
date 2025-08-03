using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class DieObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeDied(OnDied);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeDied(OnDied);
        }

        private void OnDied(IGameEntity target)
        {
            var view = _viewContext.GetWorldView().GetView(target);
            _viewContext.GetAnimationQueue().Enqueue(new DieAnimationCommand(view.transform));
        }
    }
}