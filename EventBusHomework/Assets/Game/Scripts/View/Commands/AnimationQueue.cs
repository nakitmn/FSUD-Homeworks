using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SampleGame
{
    public sealed class AnimationQueue
    {
        public bool IsActive { get; private set; }
        
        private readonly Queue<IAnimationCommand> _animationCommands = new();

        public void Enqueue(IAnimationCommand command)
        {
            _animationCommands.Enqueue(command);
        }

        public async UniTask Execute()
        {
            if (IsActive)
            {
                return;
            }
            
            IsActive = true;
            
            while (_animationCommands.Count > 0)
            {
                await _animationCommands.Dequeue().Execute();
            }
            
            IsActive = false;
        }
    }
}