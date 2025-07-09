using Atomic.Elements;
using UnityEngine;

namespace SampleGame
{
    public sealed class ManaPresenter : MonoBehaviour
    {
        [SerializeField]
        private HealthView _view;

        private IGameContext _context;
        private IValue<int> _maxMana;
        private IReactiveVariable<int> _currentMana;

        private void Awake()
        {
            _context = GameContext.Instance;
        }

        private void OnEnable()
        {
            var character = _context.GetCharacter();
            _maxMana = character.GetMaxMana();
            _currentMana = character.GetCurrentMana();
            _currentMana.Observe(OnManaChanged);
        }

        private void OnDisable()
        {
            _currentMana.Unsubscribe(OnManaChanged);
        }

        private void OnManaChanged(int mana)
        {
            var maxMana = _maxMana.Value;
            var normalizedMana = (float) mana / maxMana;
            
            _view.SetProgress(normalizedMana);
            _view.SetValue($"{mana}/{maxMana}");
        }
    }
}