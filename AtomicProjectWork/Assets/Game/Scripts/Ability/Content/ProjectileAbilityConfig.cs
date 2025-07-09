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
        [SerializeField] private SceneEntity _prefab;
        [SerializeField] private int _initialCharges;
        [SerializeField] private float _cooldown;

        protected override void Install(Ability ability, IEntity entity)
        {
            var gameContext = GameContext.Instance;

            ability.AddPointTag();

            ability.AddPointCondition(new BaseFunction<Vector3, bool>(point =>
                ability.GetCooldown().IsExpired() &&
                ability.GetCharges().Value > 0
            ));

            ability.AddPointAction(new BaseAction<Vector3>(point =>
            {
                var characterPosition = entity.GetTransform().position;
                var direction = point - characterPosition;
                direction.y = 0f;
                direction.Normalize();

                var position = entity.GetFirePoint().position;

                var projectile = SpawnBulletUseCase.SpawnBullet(_prefab, gameContext, position,
                    Quaternion.LookRotation(direction), entity);
                projectile.GetFireAction().Invoke();

                ability.GetCharges().Value--;
                ability.GetCooldown().Reset();
            }));

            ability.AddCooldown(new Cooldown(_cooldown, 0));
            ability.AddCharges(new ReactiveInt(_initialCharges));
            ability.AddPointEvent(new BaseEvent<Vector3>());
            ability.WhenFixedUpdate(ability.GetCooldown().Tick);
        }
    }
}