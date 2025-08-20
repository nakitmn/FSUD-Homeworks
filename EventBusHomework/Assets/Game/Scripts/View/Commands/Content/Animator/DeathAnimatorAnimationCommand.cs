using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public readonly struct DeathAnimatorAnimationCommand : IAnimationCommand
    {
        private static readonly int DeathHash = Animator.StringToHash("Death");
        
        private readonly Animator _animator;

        public DeathAnimatorAnimationCommand(Animator animator)
        {
            _animator = animator;
        }

        public async UniTask Execute()
        {
            _animator.SetTrigger(DeathHash);
            await UniTask.CompletedTask;
        }
    }
}