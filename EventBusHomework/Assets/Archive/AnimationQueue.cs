/*using System.Collections.Generic;
using Atomic.Events;
using NUnit.Framework;
using UnityEditor.VersionControl;

namespace DefaultNamespace
{
    public interface IAnimationCommand
    {
        Task Execute();
    }
    
    public sealed class AnimationQueue
    {
        private IEventBus _eventBus;
        
        private List<IAnimationCommand> _animationCommands;

        public void Enqueue(IAnimationCommand command)
        {
            _animationCommands.Add(command);
        }

        public async System.Threading.Tasks.Task Execute()
        {
            foreach (var command in _animationCommands)
            {
                await command.Execute();
                
            }

            _eventBus.InvokeAttackFinished();
        }
    }
}*/