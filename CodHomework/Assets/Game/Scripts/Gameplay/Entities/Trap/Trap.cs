using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Trap : MonoEntity
    {
        [SerializeField] private int _damage;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<Health>()
                .FromMethod(() => new Health())
                .AsSingle()
                .NonLazy();

            Container.Bind<CollisionEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);

            Get<CollisionEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<TakeDamageComponent>(out var takeDamageComponent))
                {
                    takeDamageComponent.Damage(_damage);
                    healthComponent.InstantDie();
                }
            };
        }
    }
}