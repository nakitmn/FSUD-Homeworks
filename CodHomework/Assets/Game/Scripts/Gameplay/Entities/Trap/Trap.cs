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
        }

        public override void Start()
        {
            Get<DamagableEntityDetectorComponent>().OnDetected += entity =>
            {
                entity.Get<Health>().Damage(_damage);
                gameObject.SetActive(false);
            };
        }
    }
}