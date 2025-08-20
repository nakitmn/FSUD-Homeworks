using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public readonly struct CharacterDealDamageAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;
        private readonly float _health;

        public CharacterDealDamageAnimationCommand(Transform target, float health)
        {
            _target = target;
            _health = health;
        }

        public async UniTask Execute()
        {
            var animator = _target.GetComponentInChildren<Animator>();
            var characterView = _target.GetComponent<CharacterView>();

            new HitAnimatorAnimationCommand(animator).Execute();
            new UpdateHealthAnimationCommand(characterView, _health).Execute();
            characterView.PlayHit();
            _target.DOKill();
            _target.localScale = Vector3.one;
            await _target.DOPunchScale(Vector3.one * 0.1f, 0.25f)
                .AsyncWaitForCompletion();
        }
    }
}