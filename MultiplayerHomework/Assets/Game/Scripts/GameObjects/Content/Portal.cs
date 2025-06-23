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
            if (_deathComponent.IsDead)
            {
                return;
            }

            if (_healthComponent.Exists() == false)
            {
                _deathComponent.IsDead = true;
            }
        }
    }
}