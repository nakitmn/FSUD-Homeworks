using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class FireDelaySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<FireDelay>> _fireDelays;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            foreach (int entity in _fireDelays.Value)
            {
                ref var fireDelay = ref _fireDelays.Pools.Inc1.Get(entity);
                
                if (fireDelay.enabled == false)
                {
                    continue;
                }

                if (fireDelay.current > 0)
                {
                    fireDelay.current -= deltaTime;
                }
            }
        }
    }
}