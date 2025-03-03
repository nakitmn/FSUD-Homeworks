using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame.Entities.Core.Target
{
    public readonly struct TargetUseCase
    {
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<Position> _positions;

        public bool Exists(in int entity)
        {
            return _targets.Value.Has(entity);
        }

        public float GetDistance(in int entity)
        {
            ref var target = ref _targets.Value.Get(entity);
            ref var selfPosition = ref _positions.Value.Get(entity);
            ref var targetPosition = ref _positions.Value.Get(target.entity);

            return math.distance(selfPosition.value, targetPosition.value);
        }
        
        public float3 GetDirection(in int entity)
        {
            ref var target = ref _targets.Value.Get(entity);
            ref var selfPosition = ref _positions.Value.Get(entity);
            ref var targetPosition = ref _positions.Value.Get(target.entity);

            return math.normalize(targetPosition.value - selfPosition.value);
        }
    }
}