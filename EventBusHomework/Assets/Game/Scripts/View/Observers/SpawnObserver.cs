using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class SpawnObserver : IInit, IEnable, IDisable
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
            var view = _viewContext.GetWorldView().GetView(entity);
            new SpawnAnimationCommand(
                view.transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, position)
            ).Execute();
        }
    }
}