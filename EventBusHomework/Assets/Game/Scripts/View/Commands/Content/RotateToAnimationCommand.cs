using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public readonly struct RotateToAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;

        public RotateToAnimationCommand(Transform target, Vector3 position)
        {
            _target = target;
            _position = position;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            var direction = _position - _target.position;
            var rotation = Quaternion.LookRotation(direction);
            await _target.DORotateQuaternion(rotation, .15f)
                .SetEase(Ease.Linear)
                .AsyncWaitForCompletion();
        }
    }
}