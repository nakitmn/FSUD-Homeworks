using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    public readonly struct JumpAnimatorAnimationCommand : IAnimationCommand
    {
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        
        private readonly Animator _animator;

        public JumpAnimatorAnimationCommand(Animator animator)
        {
            _animator = animator;
        }

        public async UniTask Execute()
        {
            _animator.SetTrigger(JumpHash);
            await UniTask.CompletedTask;
        }
    }
}