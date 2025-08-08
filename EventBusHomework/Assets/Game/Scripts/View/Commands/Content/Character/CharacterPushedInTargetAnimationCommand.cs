using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterPushedInTargetAnimationCommand : IAnimationCommand
    {
        private readonly Transform _source;
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public CharacterPushedInTargetAnimationCommand(Transform source, Transform target, Vector3 from, Vector3 to)
        {
            _source = source;
            _target = target;
            _from = from;
            _to = to;
        }

        public async UniTask Execute()
        {
            var animator = _source.GetComponentInChildren<Animator>();

            new RotateToAnimationCommand(_target, _source.position).Execute();
            new HitAnimatorAnimationCommand(animator).Execute();
            
            await DOTween.Sequence()
                .Append(
                    _source.DOMove(Vector3.Lerp(_from,_to,0.5f), 0.15f)
                        .SetEase(Ease.OutCirc)
                        .ChangeStartValue(_from)
                )
                .AsyncWaitForCompletion();

            _source.DOPunchScale(Vector3.one * 0.1f, 0.25f);
            _source.DOMove(_from, 0.25f)
                .SetEase(Ease.OutCirc);
        }
    }
}