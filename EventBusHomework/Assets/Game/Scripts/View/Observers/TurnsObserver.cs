using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class TurnsObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeStartPlayerTurn(OnPlayerTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeEndEnemyTurn(OnEnemyTurnEnded);
            _gameContext.GetEventBus().UnsubscribeStartPlayerTurn(OnPlayerTurnStart);
        }

        private void OnEnemyTurnEnded()
        {
            _viewContext.GetAnimationQueue().Execute();
        }

        private void OnPlayerTurnStart()
        {
            _viewContext.GetAnimationQueue().Execute();
        }
    }
}