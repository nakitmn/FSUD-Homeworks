using Atomic.Elements;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameStatePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;
        
        private IReactiveVariable<GameState> _currentState;

        private void Awake()
        {
            var gameContext = GameContext.Instance;
            _currentState = gameContext.GetCurrentState();
        }

        private void OnEnable()
        {
            _currentState.Observe(OnStateChanged);
        }

        private void OnDisable()
        {
            _currentState.Unsubscribe(OnStateChanged);
        }

        private void OnStateChanged(GameState gameState)
        {
            _view.text = $"Game State: {gameState}";
        }
    }
}