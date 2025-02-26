using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay.Entities.Trap
{
    public sealed class Trap : MonoEntity
    {
        [SerializeField] private int _damage;

        public override void InstallBindings()
        {
            Container.Bind<DamagableEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle();
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