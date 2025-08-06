using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public readonly struct DealDamageAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;

        public DealDamageAnimationCommand(Transform target)
        {
            _target = target;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            _target.localScale = Vector3.one;
            await _target.DOPunchScale(Vector3.one * 0.1f, 0.25f)
                .AsyncWaitForCompletion();
        }
    }
}