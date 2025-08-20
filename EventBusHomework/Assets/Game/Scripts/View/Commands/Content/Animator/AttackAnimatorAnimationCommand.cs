using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public readonly struct AttackAnimatorAnimationCommand : IAnimationCommand
    {
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        
        private readonly Animator _animator;

        public AttackAnimatorAnimationCommand(Animator animator)
        {
            _animator = animator;
        }

        public async UniTask Execute()
        {
            _animator.SetTrigger(AttackHash);
            await UniTask.CompletedTask;
        }
    }
}