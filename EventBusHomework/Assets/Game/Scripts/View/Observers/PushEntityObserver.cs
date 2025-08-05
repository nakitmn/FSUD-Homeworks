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
            var newPosition = sourcePosition + direction;
            ViewCommandsUseCase.Enqueue(_viewContext,
                new PushAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, target).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, sourcePosition),
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, newPosition)
                ));
        }

        private void OnPushedInTarget(PushInTargetEventData pushData)
        {
            ViewCommandsUseCase.Enqueue(_viewContext, new PushInTargetAnimationCommand(
                GameEntityViewUseCase.GetView(_viewContext, pushData.Source).transform,
                GameEntityViewUseCase.GetView(_viewContext, pushData.Target).transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, pushData.SourcePosition),
                GameBoardViewUseCase.GetWorldPosition(_viewContext, pushData.TargetPosition)
            ));
        }

        private void OnPushedOut(IGameEntity target, GameBoardPosition sourcePosition, Vector2Int direction)
        {
            var newPosition = sourcePosition + direction;
            var toPosition = GameBoardViewUseCase.GetWorldPosition(_viewContext, newPosition);
            toPosition.y -= 2f;
            ViewCommandsUseCase.Enqueue(_viewContext,
                new DieFromBoundsAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, target).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, sourcePosition),
                    toPosition
                ));
        }
    }
}