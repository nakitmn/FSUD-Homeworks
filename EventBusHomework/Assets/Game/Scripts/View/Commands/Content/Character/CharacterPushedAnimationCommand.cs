using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterPushedAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;

        public CharacterPushedAnimationCommand(Transform target, Vector3 position)
        {
            _target = target;
            _position = position;
        }

        public async UniTask Execute()
        {
            var animator = _target.GetComponentInChildren<Animator>();

            new HitAnimatorAnimationCommand(animator).Execute();
            await new MoveAnimationCommand(_target, _position).Execute();
        }
    }
}