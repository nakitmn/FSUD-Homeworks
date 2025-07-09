using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "TeleportAbilityConfig",
        menuName = "SampleGame/Abilities/New TeleportAbilityConfig"
    )]
    public sealed class TeleportAbilityConfig : AbilityConfig
    {
        [SerializeField] private Const<float> _radius;
        [SerializeField] private Const<int> _manaCost;
        [SerializeField] private int _initialCharges;

        protected override void Install(Ability ability, IEntity entity)
        {
            ability.AddPointTag();

            ability.AddPointCondition(new BaseFunction<Vector3, bool>(point =>
                ManaUseCase.Enough(entity, _manaCost.Value) &&
                VectorUseCase.LessOrEqualsDistance(entity, point, _radius.Value) &&
                ability.GetCharges().Value > 0
            ));

            ability.AddPointAction(new BaseAction<Vector3>(point =>
            {
                ManaUseCase.Spend(entity, _manaCost.Value);
                ability.GetCharges().Value--;

                entity.GetTeleportAction().Invoke(point);
            }));

            ability.AddPointEvent(new BaseEvent<Vector3>());
            ability.AddCharges(new ReactiveInt(_initialCharges));
            ability.AddRadius(_radius);
            ability.AddManaCost(_manaCost);
        }
    }
}