using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public readonly struct MoveAnimatorAnimationCommand : IAnimationCommand
    {
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
        
        private readonly Animator _animator;
        private readonly bool _isMoving;

        public MoveAnimatorAnimationCommand(Animator animator, bool isMoving)
        {
            _animator = animator;
            _isMoving = isMoving;
        }

        public async UniTask Execute()
        {
            _animator.SetBool(IsMovingHash, _isMoving);
            await UniTask.CompletedTask;
        }
    }
}