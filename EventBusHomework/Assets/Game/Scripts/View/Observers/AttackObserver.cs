using Atomic.Entities;
using Game.View;

namespace SampleGame
{
    public sealed class AttackObserver : IInit, IEnable, IDisable
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
            
            _viewContext.GetAnimationQueue().Enqueue(
                new AttackStartAnimationCommand(
                view.transform,
                GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.TargetPosition)
                ));
        }

        private void OnAttackEnded(AttackEventData attackData)
        {
            var view = _viewContext.GetWorldView().GetView(attackData.Source);
            
            _viewContext.GetAnimationQueue().Enqueue(
                new AttackEndAnimationCommand(
                    view.transform,
                    GameBoardViewUseCase.GetWorldPosition(_viewContext, attackData.SourcePosition)
                ));
        }
    }
}