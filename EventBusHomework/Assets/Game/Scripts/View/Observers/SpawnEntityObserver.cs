using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class SpawnEntityObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeSpawned(OnSpawned);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeSpawned(OnSpawned);
        }

        private void OnSpawned(IGameEntity entity, GameBoardPosition position)
        {
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new SpawnAnimationCommand(
                _viewContext.GetWorldView(),
                entity,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, position)
            ));
        }
    }
}