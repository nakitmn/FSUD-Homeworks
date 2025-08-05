using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class MoveEntityObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeMoved(OnMoved);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeMoved(OnMoved);
        }

        private void OnMoved(IGameEntity target, GameBoardPosition position)
        {
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new MoveAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, target).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, position))
            );
        }
    }
}