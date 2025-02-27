using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Trampoline : MonoEntity
    {
        [SerializeField] private float _force;

        public override void InstallBindings()
        {
            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<AudioSource>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<PushComponent>()
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<Rigidbody2D>(out var rigidbody))
                {
                    Get<PushComponent>().Push(rigidbody, transform.up, _force);
                    Get<AudioSource>().Play();
                }
            };
        }
    }
}