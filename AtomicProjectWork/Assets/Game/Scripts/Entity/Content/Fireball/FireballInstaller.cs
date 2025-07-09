using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class FireballInstaller : SceneEntityInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private int _damage;
        [SerializeField] private float _radius;
        [SerializeField] private float _lifetime;
        [SerializeField] private float _lengthForce;
        [SerializeField] private float _heightForce;
        [SerializeField] private TriggerEventReceiver _trigger;
        [SerializeField] private EffectConfig[] _effects;
        [SerializeField] private GameObject _destroyVfx;

        public override void Install(IEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            entity.AddRigidbody(this._rigidbody);
            entity.AddTransform(this.transform);
            entity.AddGameObject(this.gameObject);
            entity.AddDamage(new ReactiveInt(_damage));
            entity.AddDamageRadius(new Const<float>(_radius));
            entity.AddLifetime(new Cooldown(_lifetime, _lifetime));
            entity.AddOwner(new ReactiveVariable<IEntity>());

            entity.AddFireAction(new BaseAction(() =>
            {
                var rigidbody = entity.GetRigidbody();
                var direction = entity.GetTransform().forward;
                direction = (direction * _lengthForce) + (Vector3.up * _heightForce);
                rigidbody.AddForce(direction, ForceMode.Impulse);
            }));
            
            entity.AddDestroyAction(new BaseAction(() =>
            {
                if (_destroyVfx != null)
                {
                    gameContext.GetPrefabPool().Rent(_destroyVfx, transform.position, Quaternion.identity);
                }
                
                SpawnBulletUseCase.UnspawnBullet(gameContext, entity);
            }));

            entity.AddMoveDirection(new ReactiveVariable<Vector3>());
            entity.AddTrigger(_trigger);

            entity.AddProjectileEffects(_effects);

            entity.WhenDisable(() =>
            {
                entity.GetRigidbody().velocity = Vector3.zero;
            });

            entity.AddBehaviour<FireballCollisionBehaviour>();
        }
    }
}