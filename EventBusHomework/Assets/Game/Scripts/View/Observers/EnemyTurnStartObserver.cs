using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class EnemyTurnStartObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeStartEnemyTurn(OnEnemyTurnStarted);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeStartEnemyTurn(OnEnemyTurnStarted);
        }

        private void OnEnemyTurnStarted()
        {
            var animationQueue = _viewContext.GetAnimationQueue();
            animationQueue.Enqueue(new EnemyTurnStartAnimationCommand(_viewContext.GetTurnView()));
            animationQueue.Execute().Forget();
        }
    }
}