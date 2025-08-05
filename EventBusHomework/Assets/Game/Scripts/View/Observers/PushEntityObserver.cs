using Atomic.Entities;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public sealed class PushEntityObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribePushedOut(OnPushedOut);
            _gameContext.GetEventBus().SubscribePushedInTarget(OnPushedInTarget);
            _gameContext.GetEventBus().SubscribePushed(OnPushed);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribePushedOut(OnPushedOut);
            _gameContext.GetEventBus().UnsubscribePushedInTarget(OnPushedInTarget);
            _gameContext.GetEventBus().UnsubscribePushed(OnPushed);
        }

        private void OnPushed(IGameEntity target, GameBoardPosition sourcePosition, Vector2Int direction)
        {
            var view = _viewContext.GetWorldView().GetView(target);
            var newPosition = sourcePosition + direction;
            var command = new PushAnimationCommand(
                view.transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, sourcePosition),
                GameBoardViewUseCase.GetWorldPosition(_viewContext, newPosition)
            );
            _viewContext.GetAnimationQueue().Enqueue(command);
        }

        private void OnPushedInTarget(PushInTargetEventData pushData)
        {
            var command = new PushInTargetAnimationCommand(
                _viewContext.GetWorldView().GetView(pushData.Source).transform,
                _viewContext.GetWorldView().GetView(pushData.Target).transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, pushData.SourcePosition),
                GameBoardViewUseCase.GetWorldPosition(_viewContext, pushData.TargetPosition)
            );
            _viewContext.GetAnimationQueue().Enqueue(command);
        }

        private void OnPushedOut(IGameEntity target, GameBoardPosition sourcePosition, Vector2Int direction)
        {
            var view = _viewContext.GetWorldView().GetView(target);
            var newPosition = sourcePosition + direction;
            var toPosition = GameBoardViewUseCase.GetWorldPosition(_viewContext, newPosition);
            toPosition.y -= 2f;
            var command = new DieFromBoundsAnimationCommand(
                view.transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, sourcePosition),
                toPosition
            );
            _viewContext.GetAnimationQueue().Enqueue(command);
        }
    }
}