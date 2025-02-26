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
            
            Container.Bind<DamagableEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<Health>()
                .FromMethod(() => new Health())
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);
            
            Get<DamagableEntityDetectorComponent>().OnDetected += entity =>
            {
                entity.Get<Health>().Damage(_damage);
                healthComponent.Damage(1);
            };
        }
    }
}