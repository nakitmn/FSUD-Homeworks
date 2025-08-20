using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class DieEntityObserver : IInit, IEnable, IDisable
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
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new CharacterDieAnimationCommand(_viewContext, GameEntityViewUseCase.GetView(_viewContext,target).transform)
            );
        }
    }
}