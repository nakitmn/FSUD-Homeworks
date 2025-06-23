using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MoveAnimComponent : NetworkBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField] private Animator _animator;
        [SerializeField] private MoveComponent _moveComponent;

        public override void Render()
        {
            _animator.SetBool(IsMoving, _moveComponent.IsMoving);
        }
    }
}