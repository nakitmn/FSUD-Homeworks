using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SampleGame
{
    public readonly struct EnemyTurnStartAnimationCommand : IAnimationCommand
    {
        private readonly TurnView _turnView;

        public EnemyTurnStartAnimationCommand(TurnView turnView)
        {
            _turnView = turnView;
        }

        public async UniTask Execute()
        {
            _turnView.SetPlayerTurn(false);
            _turnView.SetCaption("enemy turn!");
            await _turnView.Enable().AsyncWaitForCompletion();
            await UniTask.Delay(TimeSpan.FromSeconds(0.75f));
            await _turnView.Disable().AsyncWaitForCompletion();
        }
    }
}