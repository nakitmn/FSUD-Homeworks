using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay.Entities.Spider
{
    public sealed class Spider : MonoEntity
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _damage;
        [SerializeField] private float _pushCooldown;
        [SerializeField] private float _pushForce;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<Health>()
                .FromMethod(() => new Health(_maxHealth))
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PushOutComponent>()
                .AsSingle()
                .WithArguments(_pushCooldown, _pushForce)
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);

            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<Health>(out var health))
                {
                    health.Damage(_damage);
                    Get<PushOutComponent>().Push(entity);
                }
            };
        }
    }
}