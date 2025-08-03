using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct SpawnAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;

        public SpawnAnimationCommand(Transform target, Vector3 position)
        {
            _target = target;
            _position = position;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            _target.position = _position;
            await _target.DOScale(Vector3.one, 0.5f)
                .ChangeStartValue(Vector3.zero)
                .SetLink(_target.gameObject)
                .AsyncWaitForCompletion();
        }
    }
}