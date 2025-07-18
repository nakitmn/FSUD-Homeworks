/*using System;
using Atomic.Entities;
using Atomic.Events;
using SampleGame;

namespace DefaultNamespace
{
   
    
    
    public interface ICommand
    {
        bool Execute(IGameContext gameContext);
    }
    
    public struct CharacterAttackCommand : ICommand
    {
        private IEntity source;
        private IEntity target;
        
        public bool Execute(IGameContext gameContext)
        {
            var dealDamageCommand = new DealDamageCommand(source, target);
            if (dealDamageCommand.Execute())
            {
                var pushCommand = new PushCommand(source, target);
                pushCommand.Execute();
            }
            
            gameContext.GetAnimationQueue().Enqueue(new DealDamageAnimation(source, target));
            gameContext.GetEventBus().InvokeDealDamage();
        }
    }
    
    public struct DealDamageCommand : ICommand
    {
        private IEntity source;
        private IEntity target;
        private IEventBus _eventBus;
        
        public DealDamageCommand(IEntity source, IEntity target)
        {
            this.source = source;
            this.target = target;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (!DealDamage()) return false;

            gameContext.GetAnimationQueue().Enqueue(new DealDamageAnimation(source, target));
            gameContext.GetEventBus().InvokeDealDamage();
            return true;
        }

        private bool DealDamage()
        {
            if (target.GetHealth() == 0)
                return false;

            int damage = source.GetDamage();
            int health = target.GetHealth();
            target.SetHealth(health - damage);
            return true;
        }
    }

    public struct PushCommand : ICommand
    {
        private IEntity source;
        private IEntity target;
        
        public PushCommand(IEntity source, IEntity target)
        {
        }

        public bool Execute()
        {
            var distance = target - source;
            if (wasNearEntity)
            {
                var dealDamageCommand = new DealDamageCommand(source, target);
                dealDamageCommand.Execute(queue);
                    
                var pushCommand = new PushCommand(wasNearEntity, target);
                pushCommand.Execute(queue);
            }
        }
    }
}*/