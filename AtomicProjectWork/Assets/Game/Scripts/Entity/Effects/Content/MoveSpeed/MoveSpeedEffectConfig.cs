using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "MoveSpeedEffect",
        menuName = "SampleGame/Effects/New MoveSpeedEffect"
    )]
    public sealed class MoveSpeedEffectConfig : TemporaryEffectConfig
    {
        [field: SerializeField] public Const<float> Multiplier { get; private set; }

        public override bool CanApply(in IEntity target) =>
            target.HasMoveSpeed();

        protected override Effect Create(in IEntity target) =>
            new MoveSpeedEffect(this, target);
    }
}