using Atomic.Elements;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "MoveSpeedAspect",
        menuName = "SampleGame/Aspects/New MoveSpeedAspect"
    )]
    public sealed class MoveSpeedAspect : ScriptableEntityAspect<IGameEntity>
    {
        [SerializeField]
        private Const<float> _multiplier;

        public override void Apply(IGameEntity entity)
        {
            if (entity.TryGetMoveSpeed(out IReactiveVariable<float> speed))
                speed.Value *= _multiplier.Value;
        }

        public override void Discard(IGameEntity entity)
        {
            if (entity.TryGetMoveSpeed(out IReactiveVariable<float> speed))
                speed.Value /= _multiplier.Value;
        }
    }
}