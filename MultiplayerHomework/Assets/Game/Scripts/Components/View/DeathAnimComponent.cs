using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class DeathAnimComponent : NetworkBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;
        [SerializeField] private HealthComponent _healthComponent;

        public override void Render()
        {
            _animator.SetBool(IsDead, _healthComponent.Exists() == false);
        }
    }
}