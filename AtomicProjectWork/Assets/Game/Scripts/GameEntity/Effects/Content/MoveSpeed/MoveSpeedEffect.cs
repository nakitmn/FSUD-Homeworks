using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class MoveSpeedEffect :
        TemporaryEffect
    {
        private readonly IValue<float> _multiplier;

        public MoveSpeedEffect
            (MoveSpeedEffectConfig config, IGameEntity target)
            : base(config, target)
        {
            _multiplier = config.Multiplier;
            _target.GetMoveSpeed().Value *= _multiplier.Value;
        }

        protected override void OnDispose()
        {
            _target.GetMoveSpeed().Value /= _multiplier.Value;
        }
    }
}