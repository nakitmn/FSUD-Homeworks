using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public struct PushAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public PushAnimationCommand(Transform target, Vector3 from, Vector3 to)
        {
            _target = target;
            _from = from;
            _to = to;
        }

        public async UniTask Execute()
        {
            _target.DOKill();
            await _target.DOMove(_to, 0.25f)
                .ChangeStartValue(_from)
                .AsyncWaitForCompletion();
        }
    }
}