using Atomic.Elements;
using Game.View;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class SelectedCharacterPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _view;

        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private IGameEntity _cachedCharacter;

        private void Awake()
        {
            var context = ViewContext.Instance;
            _selectedCharacter = context.GetSelectedCharacter();
        }

        private void OnEnable()
        {
            _selectedCharacter.Observe(OnSelectedCharacterChanged);
        }

        private void OnDisable()
        {
            _selectedCharacter.Unsubscribe(OnSelectedCharacterChanged);
        }

        private void OnSelectedCharacterChanged(IGameEntity selectedCharacter)
        {
            if (_cachedCharacter != null)
            {
               _cachedCharacter.GetCurrentMovesCount().Unsubscribe(OnMovesChanged);
               _cachedCharacter.GetCurrentAttacksCount().Unsubscribe(OnAttacksChanged);
            }
            
            _cachedCharacter = selectedCharacter;
            if (_cachedCharacter != null)
            {
                _cachedCharacter.GetCurrentMovesCount().Subscribe(OnMovesChanged);
                _cachedCharacter.GetCurrentAttacksCount().Subscribe(OnAttacksChanged);
            }

            _view.gameObject.SetActive(_cachedCharacter != null);
            UpdateStats();
        }

        private void UpdateStats()
        {
            if (_cachedCharacter != null)
            {
                var remainMoves = _cachedCharacter.GetMaxMovesPerTurn().Value -
                                  _cachedCharacter.GetCurrentMovesCount().Value;
                var remainAttacks = _cachedCharacter.GetMaxAttacksPerTurn().Value -
                                    _cachedCharacter.GetCurrentAttacksCount().Value;

                _view.text = $"Moves: {remainMoves}\nAttacks: {remainAttacks}";
            }
        }

        private void OnMovesChanged(int obj)
        {
            UpdateStats();
        }

        private void OnAttacksChanged(int obj)
        {
            UpdateStats();
        }
    }
}