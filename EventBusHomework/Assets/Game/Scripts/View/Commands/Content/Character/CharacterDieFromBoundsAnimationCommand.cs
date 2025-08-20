using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public readonly struct CharacterDieFromBoundsAnimationCommand : IAnimationCommand
    {
        private readonly IViewContext _viewContext;
        private readonly Transform _target;
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public CharacterDieFromBoundsAnimationCommand(IViewContext viewContext, Transform target, Vector3 from,
            Vector3 to)
        {
            _viewContext = viewContext;
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

            var prefabPool = _viewContext.GetPrefabPool();
            var waterSplashEffect = _viewContext.GetWaterSplashEffect();

            var waterSplashPosition = _to;
            waterSplashPosition.y = 0f;

            _target.DOKill();
            _target.position = _from;
            var target = _target;

            DOVirtual.DelayedCall(0.15f,
                () => prefabPool.Rent(waterSplashEffect, waterSplashPosition, Quaternion.identity)
            );

            await DOTween.Sequence()
                .Append(_target.DOJump(_to, 1f, 1, 0.25f))
                .Append(_target.DOScale(Vector3.zero, 0.25f))
                .AppendCallback(() => target.gameObject.SetActive(false))
                .AsyncWaitForCompletion();
        }
    }
}