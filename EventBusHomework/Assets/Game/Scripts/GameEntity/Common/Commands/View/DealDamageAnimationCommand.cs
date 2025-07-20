using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct DealDamageAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;

        public DealDamageAnimationCommand(Transform target)
        {
            _target = target;
        }

        public async UniTask Execute()
        {
            await _target.DOPunchScale(Vector3.one * 0.1f, 0.5f).AsyncWaitForCompletion();
        }
    }
}