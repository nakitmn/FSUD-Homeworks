using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public readonly struct CharacterPushedInTargetAnimationCommand : IAnimationCommand
    {
        private readonly ViewContext _viewContext;
        private readonly PushInTargetEventData _pushData;

        public CharacterPushedInTargetAnimationCommand(ViewContext viewContext, PushInTargetEventData pushData)
        {
            _viewContext = viewContext;
            _pushData = pushData;
        }

        public async UniTask Execute()
        {
            var source = GameEntityViewUseCase.GetView(_viewContext, _pushData.Source).transform;
            var target = GameEntityViewUseCase.GetView(_viewContext, _pushData.Target).transform;
            var from = GameBoardViewUseCase.GetWorldPosition(_viewContext, _pushData.SourcePosition);
            var to = GameBoardViewUseCase.GetWorldPosition(_viewContext, _pushData.TargetPosition);

            var sourceCharacterView = source.GetComponent<CharacterView>();
            var sourceAnimator = source.GetComponentInChildren<Animator>();

            new RotateToAnimationCommand(target, source.position).Execute();
            new HitAnimatorAnimationCommand(sourceAnimator).Execute();
            new UpdateHealthAnimationCommand(
                sourceCharacterView,
                HealthUseCase.GetNormalizedHealth(_pushData.Source)).Execute();
            
            sourceCharacterView.PlayHit();

            await DOTween.Sequence()
                .Append(
                    source.DOMove(Vector3.Lerp(from, to, 0.5f), 0.15f)
                        .SetEase(Ease.OutCirc)
                        .ChangeStartValue(from)
                )
                .AsyncWaitForCompletion();
            
            source.DOPunchScale(Vector3.one * 0.1f, 0.25f);
            source.DOMove(from, 0.25f)
                .SetEase(Ease.OutCirc);
        }
    }
}