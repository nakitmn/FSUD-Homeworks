using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerAnimatorController : NetworkBehaviour
    {
        private static readonly int State = Animator.StringToHash("State");

        [SerializeField] private NetworkMecanimAnimator _animator;
        [SerializeField] private InputReceiver _inputReceiver;

        public override void Render()
        {
            _animator.Animator.SetInteger(State,
                _inputReceiver.InputData.moveDirection != Vector3.zero ? 1 : 0);
        }
    }
}