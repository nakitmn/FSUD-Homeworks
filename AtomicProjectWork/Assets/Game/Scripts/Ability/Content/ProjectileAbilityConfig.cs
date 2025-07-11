using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "ProjectileAbilityConfig",
        menuName = "SampleGame/Abilities/New ProjectileAbilityConfig"
    )]
    public sealed class ProjectileAbilityConfig : AbilityConfig
    {
        [SerializeField] private GameEntity _prefab;
        [SerializeField] private int _initialCharges;
        [SerializeField] private float _cooldown;
        [SerializeField] private string _animationKey;
        [SerializeField] private float _throwDelay;

        protected override void Install(Ability ability, IGameEntity entity)
        {
            var animationHash = Animator.StringToHash(_animationKey);
            var gameContext = GameContext.Instance;

            ability.AddPointTag();

            ability.AddPointCondition(new BaseFunction<Vector3, bool>(point =>
                ability.GetCooldown().IsExpired() &&
                ability.GetIsRunning().Value == false &&
                ability.GetCharges().Value > 0
            ));

            ability.AddPointAction(new BaseAction<Vector3>(point =>
            {
                entity.GetAnimator().SetTrigger(animationHash);
                entity.GetStopAction().Invoke();

                ability.GetCharges().Value--;
                ability.GetCooldown().Reset();
                ability.GetDelay().Reset();
                ability.GetIsRunning().Value = true;
                ability.GetTargetPoint().Value = point;
            }));

            ability.AddIsRunning(new ReactiveBool(false));
            ability.AddCooldown(new Cooldown(_cooldown + _throwDelay, 0));
            ability.AddTargetPoint(new ReactiveVector3());
            ability.AddDelay(new Cooldown(_throwDelay, 0));
            ability.AddCharges(new ReactiveInt(_initialCharges));
            ability.AddPointEvent(new BaseEvent<Vector3>());

            ability.WhenFixedUpdate(deltaTime =>
            {
                ability.GetCooldown().Tick(deltaTime);
                ability.GetDelay().Tick(deltaTime);
            });
            
            ability.AddBehaviour(new RotateToTargetPointBehaviour(entity));
            ability.AddBehaviour<DelayRunningBehaviour>();
            
            ability.GetIsRunning().Subscribe(isRunning =>
            {
                if (isRunning == false)
                {
                    var firePoint = entity.GetFirePoint();
                    SpawnProjectileUseCase.Spawn(_prefab, gameContext, firePoint.position,
                        firePoint.rotation, entity);
                }
            });
        }
    }
}