using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Lava : MonoEntity
    {
        public override void InstallBindings()
        {
            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle();
                   
            Container.Bind<AudioSource>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        public override void Start()
        {
            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<Health>(out var health))
                {
                    Get<AudioSource>().Play();
                    health.InstantDie();
                }
            };
        }
    }
}