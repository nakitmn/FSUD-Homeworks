using Atomic.Elements;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterHealthPresenter : MonoBehaviour
    {
        [SerializeField] private HealthView _view;

        private IGameEntity _character;
        private IReactiveVariable<int> _maxHealth;

        private void Awake()
        {
            _character = GameContext.Instance.GetCharacter();
        }

        private void OnEnable()
        {
            _maxHealth = _character.GetMaxHealth();
            _character.GetHealth().Observe(this.OnHealthChanged);
        }

        private void OnDisable()
        {
            _character.GetHealth().Unsubscribe(this.OnHealthChanged);
        }

        private void OnHealthChanged(int health)
        {
            var maxHealth = _maxHealth.Value;
            var normalizedHealth = (float) health / maxHealth;
            
            _view.SetProgress(normalizedHealth);
            _view.SetValue($"{health}/{maxHealth}");
        }
    }
}