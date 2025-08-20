using Atomic.Entities;
using Atomic.Events;
using Game.View;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class EndTurnButtonPresenter : IEnable<IViewContext>, IDisable
    {
        private readonly Button _button;

        private IEventBus _eventBus;
        private IViewContext _viewContext;

        public EndTurnButtonPresenter(Button button)
        {
            _button = button;
        }

        public void Enable(IViewContext entity)
        {
            var gameContext = GameContext.Instance;
            _viewContext = entity;
            _eventBus = gameContext.GetEventBus();

            _eventBus.SubscribeStartPlayerTurn(OnPlayerTurnStarted);
            _eventBus.SubscribeEndPlayerTurn(OnPlayerTurnEnded);
            _button.onClick.AddListener(OnClicked);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartPlayerTurn(OnPlayerTurnStarted);
            _eventBus.UnsubscribeEndPlayerTurn(OnPlayerTurnEnded);
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            _eventBus.InvokeEndPlayerTurn();
        }

        private void OnPlayerTurnEnded()
        {
            _button.gameObject.SetActive(false);
        }

        private void OnPlayerTurnStarted()
        {
            ViewCommandsUseCase.Enqueue(_viewContext,
                new CallbackAnimationCommand(() => _button.gameObject.SetActive(true))
            );
        }
    }
}