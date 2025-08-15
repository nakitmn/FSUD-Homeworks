using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public readonly struct UpdateHealthAnimationCommand : IAnimationCommand
    {
        private readonly CharacterView _characterView;
        private readonly float _health;

        public UpdateHealthAnimationCommand(CharacterView characterView, float health)
        {
            _characterView = characterView;
            _health = health;
        }

        public async UniTask Execute()
        {
            _characterView.SetHealth(_health);
            await UniTask.CompletedTask;
        }
    }
}