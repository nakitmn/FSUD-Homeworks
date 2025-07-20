using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct MoveAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;

        public MoveAnimationCommand(Transform target, Vector3 position)
        {
            _target = target;
            _position = position;
        }

        public async UniTask Execute()
        {
            await _target.DOMove(_position, 0.5f).AsyncWaitForCompletion();
        }
    }
}