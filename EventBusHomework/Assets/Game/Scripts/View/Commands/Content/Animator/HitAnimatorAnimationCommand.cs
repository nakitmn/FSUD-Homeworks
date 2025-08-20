using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public readonly struct HitAnimatorAnimationCommand : IAnimationCommand
    {
        private static readonly int HitHash = Animator.StringToHash("Hit");
        
        private readonly Animator _animator;

        public HitAnimatorAnimationCommand(Animator animator)
        {
            _animator = animator;
        }

        public async UniTask Execute()
        {
            _animator.SetTrigger(HitHash);
            await UniTask.CompletedTask;
        }
    }
}