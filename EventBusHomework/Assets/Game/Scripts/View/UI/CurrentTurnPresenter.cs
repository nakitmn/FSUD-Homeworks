using Atomic.Elements;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class CurrentTurnPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;
        
        private IReactiveVariable<int> _turn;

        private void Awake()
        {
            var gameContext = GameContext.Instance;
            _turn = gameContext.GetTurn();
        }

        private void OnEnable()
        {
            _turn.Observe(OnTurnChanged);
        }

        private void OnDisable()
        {
            _turn.Unsubscribe(OnTurnChanged);
        }

        private void OnTurnChanged(int turn)
        {
            _view.text = $"Turn: {turn}";
        }
    }
}