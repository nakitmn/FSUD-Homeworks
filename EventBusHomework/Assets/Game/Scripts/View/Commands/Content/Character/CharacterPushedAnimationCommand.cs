using Cysharp.Threading.Tasks;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterPushedAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;
        private readonly float _health;

        public CharacterPushedAnimationCommand(Transform target, Vector3 position, float health)
        {
            _target = target;
            _position = position;
            _health = health;
        }

        public async UniTask Execute()
        {
            var animator = _target.GetComponentInChildren<Animator>();
            var characterView = _target.GetComponent<CharacterView>();

            new HitAnimatorAnimationCommand(animator).Execute();
            new UpdateHealthAnimationCommand(characterView, _health).Execute();
            await new MoveAnimationCommand(_target, _position).Execute();
        }
    }
}