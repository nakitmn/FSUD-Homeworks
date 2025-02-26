using Modules.Entity;
using Modules.Health;

namespace Game.Gameplay
{
    public sealed class Lava : MonoEntity
    {
        public override void InstallBindings()
        {
            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        public override void Start()
        {
            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<Health>(out var health))
                {
                    health.InstantDie();
                }
            };
        }
    }
}