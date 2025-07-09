using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DeathBehaviour : IInit, IDispose
    {
        private IReactiveValue<int> _health;
        private IEvent _deathEvent;

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _deathEvent = entity.GetDeathEvent();
            _health.Subscribe(OnHealthChanged);
        }
        
        public void Dispose(in IEntity entity)
        {
            _health.Unsubscribe(OnHealthChanged);
        }
    
        private void OnHealthChanged(int health)
        {
            if (health <= 0)
            {
                _deathEvent.Invoke();
            }
        }
    }
}