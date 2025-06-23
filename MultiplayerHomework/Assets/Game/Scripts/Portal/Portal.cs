using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Portal : NetworkBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DeathComponent _deathComponent;

        public bool IsDead => _deathComponent.IsDead;

        public override void FixedUpdateNetwork()
        {
            _deathComponent.IsDead = _healthComponent.Exists() == false;
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }
    }
}