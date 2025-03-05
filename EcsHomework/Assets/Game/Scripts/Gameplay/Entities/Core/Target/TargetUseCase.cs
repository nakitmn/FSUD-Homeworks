using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame.Entities.Core.Target
{
    public readonly struct TargetUseCase
    {
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUseCase;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;

        public bool IsTargetAlive(in int entity)
        {
            return _healthUseCase.Value.Exists(_targets.Value.Get(entity).entity);
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

        public bool GetClosest(in int entity, EcsFilter filter, out int targetEntity)
        {
            ref var entityPosition = ref _positions.Value.Get(entity);
            var closest = float.MaxValue;
            targetEntity = -1;

            foreach (int target in filter)
            {
                if (target == entity)
                {
                    continue;
                }

                if (_teamUseCase.Value.AreEnemies(entity, target) == false)
                {
                    continue;
                }

                if (_healthUseCase.Value.Exists(target) == false)
                {
                    continue;
                }

                ref var targetEntityPosition = ref _positions.Value.Get(target);

                var distance = math.distance(targetEntityPosition.value, entityPosition.value);
                if (distance < closest)
                {
                    targetEntity = target;
                    closest = distance;
                }
            }

            return targetEntity > -1;
        }
    }
}