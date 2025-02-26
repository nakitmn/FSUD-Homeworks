using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay.Entities.Trampoline
{
    public sealed class Trampoline : MonoEntity
    {
        [SerializeField] private float _force;
        [SerializeField] private float _cooldown;
        
        public override void InstallBindings()
        {
            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<PushUpComponent>()
                .AsSingle()
                .WithArguments(_cooldown, _force)
                .NonLazy();
        }

        public override void Start()
        {
            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                Get<PushUpComponent>().Push(entity);
            };
        }
    }
}