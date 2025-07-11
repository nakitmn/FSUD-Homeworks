using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class RestoreManaBehaviour : IInit<IGameEntity>, IFixedUpdate
    {
        private readonly Cooldown _period;
        private readonly IValue<int> _restore;

        private IValue<int> _maxMana;
        private IVariable<int> _currentMana;

        public RestoreManaBehaviour(Cooldown period, IValue<int> restore)
        {
            _period = period;
            _restore = restore;
        }

        public void Init(IGameEntity entity)
        {
            _currentMana = entity.GetCurrentMana();
            _maxMana = entity.GetMaxMana();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (_currentMana.Value == _maxMana.Value)
                return;
            
            _period.Tick(deltaTime);
            if (!_period.IsExpired())
                return;

            _currentMana.Value += _restore.Value;
            _period.Reset();
        }
    }
}