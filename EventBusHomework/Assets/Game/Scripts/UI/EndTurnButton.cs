using Atomic.Events;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class EndTurnButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IEventBus _eventBus;

        private void Awake()
        {
            var gameContext = GameContext.Instance;
            _eventBus = gameContext.GetEventBus();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            _eventBus.InvokeEndTurn();
        }
    }
}