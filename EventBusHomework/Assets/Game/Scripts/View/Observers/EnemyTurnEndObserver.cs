using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class EnemyTurnEndObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeEndEnemyTurn(OnEnemyTurnEnded);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeEndEnemyTurn(OnEnemyTurnEnded);
        }

        private void OnEnemyTurnEnded()
        {
            _viewContext.GetAnimationQueue().Execute().Forget();
        }
    }
}