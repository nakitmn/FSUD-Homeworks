using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public readonly struct CharacterAttackEndAnimationCommand : IAnimationCommand
    {
        private readonly Transform _source;
        private readonly Vector3 _sourcePosition;

        public CharacterAttackEndAnimationCommand(Transform source, Vector3 sourcePosition)
        {
            _source = source;
            _sourcePosition = sourcePosition;
        }

        public async UniTask Execute()
        {
            var animator = _source.GetComponentInChildren<Animator>();
            
            var moveBackCommand = new MoveAnimationCommand(_source, _sourcePosition);
            var jumpAnimationCommand = new JumpAnimatorAnimationCommand(animator);

            await UniTask.Delay(TimeSpan.FromSeconds(.25f));
            jumpAnimationCommand.Execute();
            await UniTask.Delay(TimeSpan.FromSeconds(.1f));
            await moveBackCommand.Execute();
        }
    }
}