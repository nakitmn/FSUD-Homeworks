using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class LifetimeBehaviour : IFixedUpdate
    {
        private readonly Cooldown _lifetime;
        private readonly IAction _destroyAction;

        public LifetimeBehaviour(Cooldown lifetime, IAction destroyAction)
        {
            _lifetime = lifetime;
            _destroyAction = destroyAction;
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _lifetime.Tick(deltaTime);
            
            if (_lifetime.IsExpired()) 
                _destroyAction.Invoke();
        }
    }
}