using System;
using Cysharp.Threading.Tasks;

namespace SampleGame
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