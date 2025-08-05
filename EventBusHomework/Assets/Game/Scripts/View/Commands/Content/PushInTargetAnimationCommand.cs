using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct PushInTargetAnimationCommand : IAnimationCommand
    {
        private readonly Transform _source;
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public PushInTargetAnimationCommand(Transform source, Transform target, Vector3 from, Vector3 to)
        {
            _source = source;
            _target = target;
            _from = from;
            _to = to;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            _source.DOKill();
            
            await DOTween.Sequence()
                .Append(
                    _source.DOMove(_to, 0.15f)
                        .SetEase(Ease.OutCirc)
                        .ChangeStartValue(_from)
                    )
                .Join(
                    _target.DOPunchScale(Vector3.one * 0.1f, 0.25f)
                    )
                .Join( _source.DOMove(_from, 0.25f)
                    .SetEase(Ease.OutCirc)
                )
                .AsyncWaitForCompletion();
        }
    }
}