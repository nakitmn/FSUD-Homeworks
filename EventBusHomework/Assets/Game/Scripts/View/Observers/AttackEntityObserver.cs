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
            var sourceView = GameEntityViewUseCase.GetView(_viewContext, attackData.Source);
            var targetView = GameEntityViewUseCase.GetView(_viewContext, attackData.Target);

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new CharacterAttackStartAnimationCommand(sourceView.transform, targetView.transform)
            );

            /*
                   var animator = sourceView.GetComponentInChildren<Animator>();
            var targetPosition = GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.TargetPosition);

             ViewCommandsUseCase.Enqueue(
                _viewContext,
                new RotateToAnimationCommand(sourceView.transform, targetPosition)
            );

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new JumpAnimatorAnimationCommand(animator)
            );

            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new AttackStartAnimationCommand(sourceView.transform, targetPosition)
            );*/
        }

        private void OnAttackEnded(AttackEventData attackData)
        {
            ViewCommandsUseCase.Enqueue(
                _viewContext,
                new CharacterAttackEndAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, attackData.Source).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.SourcePosition))
            );
            
            /*ViewCommandsUseCase.Enqueue(
                _viewContext,
                new AttackEndAnimationCommand(
                    GameEntityViewUseCase.GetView(_viewContext, attackData.Source).transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.SourcePosition))
            );*/
        }
    }
}