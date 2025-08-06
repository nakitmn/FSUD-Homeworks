using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public readonly struct DieAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;

        public DieAnimationCommand(Transform target)
        {
            _target = target;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            await _target.DOScale(Vector3.zero, 0.5f)
                .AsyncWaitForCompletion();
        }
    }
}