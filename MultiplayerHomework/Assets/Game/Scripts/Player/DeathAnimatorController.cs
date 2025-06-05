using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class DeathAnimatorController : NetworkBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        [SerializeField] private NetworkMecanimAnimator _animator;
        [SerializeField] private HealthComponent _healthComponent;

        public override void Render()
        {
            _animator.Animator.SetBool(IsDead, _healthComponent.Exists() == false);
        }
    }
}