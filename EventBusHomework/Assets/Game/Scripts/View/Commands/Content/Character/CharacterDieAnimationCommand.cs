using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public readonly struct CharacterDieAnimationCommand : IAnimationCommand
    {
        private readonly Transform _target;

        public CharacterDieAnimationCommand(Transform target)
        {
            _target = target;
        }

        public async UniTask Execute()
        {
            var animator = _target.GetComponentInChildren<Animator>();
            var characterView = _target.GetComponent<CharacterView>();

            new DeathAnimatorAnimationCommand(animator).Execute();
            new UpdateHealthAnimationCommand(characterView, 0).Execute();
            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
            
            var target = _target;
            _target.DOScale(Vector3.zero, 0.5f)
                .OnComplete(()=> target.gameObject.SetActive(false))
                .SetTarget(_target.gameObject);
        }
    }
}