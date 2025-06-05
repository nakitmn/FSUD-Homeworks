using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Portal : NetworkBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }
    }
}