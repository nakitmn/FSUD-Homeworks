using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class PortalHealthPresenter : MonoBehaviour
    {
        [SerializeField] private SmoothHealthBar _smoothHealthBar;
        
        private HealthComponent _portalHealth;

        [Inject]
        public void Construct(Portal portal)
        {
            _portalHealth = portal.GetComponent<HealthComponent>();
        }

        private void OnEnable()
        {
            _portalHealth.OnHealthChanged += OnHealthChanged;
            
            if (_portalHealth.StateBufferIsValid)
            {
                _smoothHealthBar.Set(_portalHealth.NormalizedHealth, false);
                _smoothHealthBar.SetCaption($"{_portalHealth.Health}/{_portalHealth.MaxHealth}");
            }
        }

        private void OnDisable()
        {
            _portalHealth.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            _smoothHealthBar.Set(_portalHealth.NormalizedHealth, true);
            _smoothHealthBar.SetCaption($"{_portalHealth.Health}/{_portalHealth.MaxHealth}");
        }
    }
}