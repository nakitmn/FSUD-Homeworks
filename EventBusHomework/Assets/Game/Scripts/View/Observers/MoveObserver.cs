using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class MoveObserver : IInit, IEnable, IDisable
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
            var view = _viewContext.GetWorldView().GetView(target);
            var command = new MoveAnimationCommand(
                view.transform, 
                GameBoardViewUseCase.GetWorldPosition(_viewContext, position));
            _viewContext.GetAnimationQueue().Enqueue(command);
        }
    }
}