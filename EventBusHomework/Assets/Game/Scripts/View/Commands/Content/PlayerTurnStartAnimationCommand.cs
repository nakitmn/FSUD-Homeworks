using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

namespace SampleGame
{
    public readonly struct PlayerTurnStartAnimationCommand : IAnimationCommand
    {
        private readonly TurnView _turnView;
        private readonly Button _endTurnButton;

        public PlayerTurnStartAnimationCommand(TurnView turnView, Button endTurnButton)
        {
            _turnView = turnView;
            _endTurnButton = endTurnButton;
        }

        public async UniTask Execute()
        {
            _turnView.SetCaption("your turn!");
            await _turnView.Enable().AsyncWaitForCompletion();
            await UniTask.Delay(TimeSpan.FromSeconds(0.75f));
            await _turnView.Disable().AsyncWaitForCompletion();
            _endTurnButton.gameObject.SetActive(true);
        }
    }
}