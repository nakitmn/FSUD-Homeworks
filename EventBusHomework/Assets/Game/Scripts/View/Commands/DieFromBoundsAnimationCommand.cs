using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct DieFromBoundsAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _position;

        public DieFromBoundsAnimationCommand(Transform target, Vector3 position)
        {
            _target = target;
            _position = position;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            await DOTween.Sequence()
                .Append(_target.DOJump(_position, 1f,1,0.25f))
                .Append(_target.DOScale(Vector3.zero, 0.25f))
                .AsyncWaitForCompletion();
        }
    }
}