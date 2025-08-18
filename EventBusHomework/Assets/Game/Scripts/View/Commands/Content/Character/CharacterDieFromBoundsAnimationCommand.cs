using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterDieFromBoundsAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public CharacterDieFromBoundsAnimationCommand(Transform target, Vector3 from, Vector3 to)
        {
            _target = target;
            _from = from;
            _to = to;
        }

        public async UniTask Execute()
        {
            var animator = _target.GetComponentInChildren<Animator>();
            var characterView = _target.GetComponent<CharacterView>();

            new HitAnimatorAnimationCommand(animator).Execute();
            new UpdateHealthAnimationCommand(characterView, 0).Execute();
            characterView.PlayHit();
            
            _target.DOKill();
            _target.position = _from;
            await DOTween.Sequence()
                .Append(_target.DOJump(_to, 1f,1,0.25f))
                .Append(_target.DOScale(Vector3.zero, 0.25f))
                .AsyncWaitForCompletion();
        }
    }
}