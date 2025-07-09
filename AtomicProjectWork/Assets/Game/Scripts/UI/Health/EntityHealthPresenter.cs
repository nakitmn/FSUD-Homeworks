using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public class EntityHealthPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private ProgressBarFiller _progressBarFiller;
        [SerializeField] private SceneEntity _entity;
        
        private IReactiveVariable<int> _maxHealth;
        private IReactiveVariable<int> _health;

        private void OnEnable()
        {
            _maxHealth = _entity.GetMaxHealth();
            _health = _entity.GetHealth();
            
            _health.Observe(OnHealthChanged);
        }

        private void OnDisable()
        {
            _health.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int health)
        {
            _container.SetActive(health > 0);
            
            var maxHealth = _maxHealth.Value;
            var normalizedHealth = (float) health / maxHealth;
            
            _progressBarFiller.FillAmount = normalizedHealth;
        }
    }
}