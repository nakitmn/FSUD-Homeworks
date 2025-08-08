using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterAttackStartAnimationCommand : IAnimationCommand
    {
        private readonly Transform _source;
        private readonly Transform _target;

        public CharacterAttackStartAnimationCommand(Transform source, Transform target)
        {
            _source = source;
            _target = target;
        }

        public async UniTask Execute()
        {
            var animator = _source.GetComponentInChildren<Animator>();
            var targetPosition = _target.position;
            var movePosition = Vector3.Lerp(_source.position, targetPosition, 0.4f);

            await new RotateToAnimationCommand(_source, movePosition).Execute();
            new JumpAnimatorAnimationCommand(animator).Execute();
            await new MoveAnimationCommand(_source, movePosition).Execute();
            new AttackAnimatorAnimationCommand(animator).Execute();
            await UniTask.Delay(TimeSpan.FromSeconds(.5f));
        }
    }
}