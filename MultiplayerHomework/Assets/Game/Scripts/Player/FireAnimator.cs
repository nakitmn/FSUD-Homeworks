using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class FireAnimator : MonoBehaviour
    {
        private static readonly int Fire = Animator.StringToHash("Fire");

        [SerializeField] private Animator _animator;

        public void PlayFire()
        {
            _animator.SetTrigger(Fire);
        }
    }
}