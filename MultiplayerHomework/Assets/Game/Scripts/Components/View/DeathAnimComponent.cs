using UnityEngine;

namespace Game
{
    public sealed class DeathAnimComponent : MonoBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;
        [SerializeField] private DeathComponent _deathComponent;

        private void OnEnable()
        {
            _deathComponent.OnDeadChanged += OnDeadChanged;
        }

        private void OnDisable()
        {
            _deathComponent.OnDeadChanged -= OnDeadChanged;
        }

        private void OnDeadChanged(bool isDead)
        {
            _animator.SetBool(IsDead, isDead);
        }
    }
}