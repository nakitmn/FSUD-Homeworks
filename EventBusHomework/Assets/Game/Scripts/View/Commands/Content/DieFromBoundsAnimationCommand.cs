using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct DieFromBoundsAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public DieFromBoundsAnimationCommand(Transform target, Vector3 from, Vector3 to)
        {
            _target = target;
            _from = from;
            _to = to;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            _target.position = _from;
            await DOTween.Sequence()
                .Append(_target.DOJump(_to, 1f,1,0.25f))
                .Append(_target.DOScale(Vector3.zero, 0.25f))
                .AsyncWaitForCompletion();
        }
    }
}