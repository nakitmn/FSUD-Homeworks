using Atomic.Entities;
using Game.View;
using UnityEditor;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackEntityObserver : IInit, IEnable, IDisable
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
            _gameContext.GetEventBus().SubscribeAttackStarted(OnAttackStarted);
            _gameContext.GetEventBus().SubscribeAttackEnded(OnAttackEnded);
        }

        public void Disable(in IEntity entity)
        {
            _gameContext.GetEventBus().UnsubscribeAttackStarted(OnAttackStarted);
            _gameContext.GetEventBus().UnsubscribeAttackEnded(OnAttackEnded);
        }

        private void OnAttackStarted(AttackEventData attackData)
        {
            var view = _viewContext.GetWorldView().GetView(attackData.Source);
            var animator = view.GetComponentInChildren<Animator>();
            var targetPosition = GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.TargetPosition);

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new RotateToAnimationCommand(view.transform, targetPosition)
            );
            
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new JumpAnimatorAnimationCommand(animator)
            );
            
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new AttackStartAnimationCommand(view.transform, targetPosition)
            );
        }

        private void OnAttackEnded(AttackEventData attackData)
        {
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new AttackEndAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, attackData.Source).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.SourcePosition))
            );
        }
    }
}