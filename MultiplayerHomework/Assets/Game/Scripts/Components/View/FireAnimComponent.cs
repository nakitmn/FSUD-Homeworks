using UnityEngine;

namespace Game
{
    public sealed class FireAnimComponent : MonoBehaviour
    {
        private static readonly int Fire = Animator.StringToHash("Fire");

        [SerializeField] private Animator _animator;
        [SerializeField] private FireComponent _fireComponent;

        private void OnEnable()
        {
            _fireComponent.OnFireStarted += OnFireStarted;
        }

        private void OnDisable()
        {
            _fireComponent.OnFireStarted -= OnFireStarted;
        }

        private void OnFireStarted()
        {
            _animator.SetTrigger(Fire);
        }
    }
}