using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class BulletInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private int _damage;
        [SerializeField] private TriggerEventReceiver _trigger;
        [SerializeField] private float _lifetime;
        [SerializeField] private EffectConfig[] _effects;
        [SerializeField] private GameObject _destroyVfx;

        protected override void Install(IGameEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            entity.AddTransform(this.transform);
            entity.AddGameObject(this.gameObject);
            entity.AddDamage(new ReactiveInt(_damage));

            entity.AddOwner(new ReactiveVariable<IGameEntity>());

            entity.AddLifetime(new Cooldown(_lifetime, _lifetime));
            entity.AddFireAction(new BaseAction());
            entity.AddDestroyAction(new BaseAction(() =>
            {
                if (_destroyVfx != null)
                {
                    gameContext.GetPrefabPool().Rent(_destroyVfx, transform.position, Quaternion.identity);
                }

                SpawnBulletUseCase.UnspawnBullet(gameContext, entity);
            }));

            entity.AddMoveSpeed(new ReactiveFloat(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector3>());
            entity.AddTrigger(_trigger);

            entity.AddProjectileEffects(_effects);

            entity.AddBehaviour<BulletLifetimeBehaviour>();
            entity.AddBehaviour<MoveTowardsBehaviour>();
            entity.AddBehaviour<BulletCollisionBehaviour>();
        }
    }
}