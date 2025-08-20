using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class PlayerTurnStartObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeStartPlayerTurn(OnPlayerTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeStartPlayerTurn(OnPlayerTurnStart);
        }

        private void OnPlayerTurnStart()
        {
            var animationQueue = _viewContext.GetAnimationQueue();
            animationQueue.Enqueue(new PlayerTurnStartAnimationCommand(_viewContext.GetTurnView(), _viewContext.GetEndTurnButton()));
            animationQueue.Execute().Forget();
        }
    }
}