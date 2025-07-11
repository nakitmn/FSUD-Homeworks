using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class DelayRunningBehaviour : IInit<Ability>, IFixedUpdate
    {
        private IReactiveVariable<bool> _isRunning;
        private Cooldown _delay;

        public void Init(Ability ability)
        {
            _isRunning = ability.GetIsRunning();
            _delay = ability.GetDelay();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (_isRunning.Value && _delay.IsExpired())
            {
                _isRunning.Value = false;
            }
        }
    }
}