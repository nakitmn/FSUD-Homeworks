using System;
using Cysharp.Threading.Tasks;

namespace Game.View
{
    public readonly struct CallbackAnimationCommand : IAnimationCommand
    {
        private readonly Action _callback;

        public CallbackAnimationCommand(Action callback)
        {
            _callback = callback;
        }

        public async UniTask Execute()
        {
            _callback?.Invoke();
            await UniTask.CompletedTask;
        }
    }
}