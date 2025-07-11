using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;

namespace SampleGame
{
    public abstract class TemporaryEffect : Effect,
        IFixedUpdate
    {
        private readonly IValue<float> _duration;

        [ShowInInspector, ReadOnly]
        private float _currentTime;

        protected TemporaryEffect(
            TemporaryEffectConfig config, IEntity entity
        ) : base(config, entity)
        {
            _duration = config.Duration;
        }

        public virtual void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _currentTime += deltaTime;
            if (_currentTime >= _duration.Value)
                EffectUseCase.Discard(entity, this.Name);
        }
    }
}