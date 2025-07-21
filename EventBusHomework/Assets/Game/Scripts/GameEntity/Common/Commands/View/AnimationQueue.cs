using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SampleGame
{
    public sealed class AnimationQueue
    {
        public bool IsActive { get; private set; }
        
        private readonly List<IAnimationCommand> _animationCommands = new();

        public void Enqueue(IAnimationCommand command)
        {
            _animationCommands.Add(command);
        }

        public async UniTask Execute()
        {
            IsActive = true;
            
            foreach (var command in _animationCommands)
            {
                await command.Execute();
            }
            
            _animationCommands.Clear();
            IsActive = false;
        }
    }
}