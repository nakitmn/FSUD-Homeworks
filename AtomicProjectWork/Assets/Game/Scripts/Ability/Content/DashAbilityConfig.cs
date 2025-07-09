using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "DashAbilityConfig",
        menuName = "SampleGame/Abilities/New DashAbilityConfig"
    )]
    public sealed class DashAbilityConfig : AbilityConfig
    {
        [SerializeField]
        private int _initialCharges;

        [SerializeField]
        private MoveSpeedEffectConfig _effect;

        protected override void Install(Ability ability, IEntity entity)
        {
            ability.AddBaseTag();
            
            ability.AddBaseCondition(new BaseFunction<bool>(
                () => ability.GetCharges().Value > 0 &&
                      EffectUseCase.CanApply(entity, _effect))
            );
            ability.AddBaseAction(new BaseAction(() =>
            {
                ability.GetCharges().Value--;
                EffectUseCase.Apply(entity, _effect);
            }));

            ability.AddBaseEvent(new BaseEvent());

            ability.AddCharges(new ReactiveInt(_initialCharges));
        }
    }
}