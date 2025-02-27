using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class VictoryZone : MonoEntity
    {
        public override void InstallBindings()
        {
            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<AudioSource>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        public override void Start()
        {
            var entityDetectorComponent = Get<TriggerEntityDetectorComponent>();
            entityDetectorComponent.OnDetected += entity =>
            {
                if (entity is Character)
                {
                    Get<AudioSource>().Play();
                    entityDetectorComponent.enabled = false;
                }
            };
        }
    }
}