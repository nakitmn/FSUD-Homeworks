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
        [SerializeField] private float _delay;
        [SerializeField] private string _animationKey;
        [SerializeField] private GameObject _pointChargeVfx;
        [SerializeField] private GameObject _endVfx;

        protected override void Install(Ability ability, IGameEntity entity)
        {
            var gameContext = GameContext.Instance;

            var animationHash = Animator.StringToHash(_animationKey);

            ability.AddPointTag();

            ability.AddPointCondition(new BaseFunction<Vector3, bool>(point =>
                ManaUseCase.Enough(entity, _manaCost.Value) &&
                ability.GetIsRunning().Value == false &&
                VectorUseCase.LessOrEqualsDistance(entity, point, _radius.Value) &&
                ability.GetCharges().Value > 0
            ));

            ability.AddPointAction(new BaseAction<Vector3>(point =>
            {
                entity.GetAnimator().SetTrigger(animationHash);
                entity.GetStopAction().Invoke();

                ManaUseCase.Spend(entity, _manaCost.Value);
                ability.GetCharges().Value--;
                ability.GetDelay().Reset();
                ability.GetIsRunning().Value = true;
                ability.GetTargetPoint().Value = point;
                
                gameContext.GetPrefabPool().Rent(_pointChargeVfx, point + Vector3.up, _pointChargeVfx.transform.rotation);
            }));

            ability.AddIsRunning(new ReactiveBool(false));
            ability.AddTargetPoint(new ReactiveVector3());
            ability.AddDelay(new Cooldown(_delay, 0f));
            ability.AddPointEvent(new BaseEvent<Vector3>());
            ability.AddCharges(new ReactiveInt(_initialCharges));
            ability.AddRadius(_radius);
            ability.AddManaCost(_manaCost);
            ability.WhenFixedUpdate(deltaTime =>
            {
                var delay = ability.GetDelay();
                var isRunning = ability.GetIsRunning();

                delay.Tick(deltaTime);

                if (isRunning.Value && delay.IsExpired())
                {
                    isRunning.Value = false;
                    var point = ability.GetTargetPoint().Value;
                    entity.GetTeleportAction().Invoke(point);
                    gameContext.GetPrefabPool().Rent(_endVfx, point + Vector3.up * 0.4f, _endVfx.transform.rotation);
                }
            });
        }
    }
}