using Atomic.Entities;
using Game.View;
using UnityEngine;

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
            var entityView = GameEntityViewUseCase.GetView(_viewContext, target);
            var animator = entityView.GetComponentInChildren<Animator>();
            var targetPosition = GameBoardViewUseCase.GetWorldPosition(_viewContext, position);

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new RotateToAnimationCommand(entityView.transform, targetPosition)
            );

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new MoveAnimatorAnimationCommand(animator, true)
            );

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new MoveAnimationCommand(entityView.transform, targetPosition)
            );

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new MoveAnimatorAnimationCommand(animator, false)
            );
        }
    }
}