using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame.Entities.Core.Target
{
    public readonly struct TargetUseCase
    {
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<UnitAttackDistance> _attackDistances;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUseCase;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsWorldInject _world;

        public bool IsTargetExist(in int entity, out int unpackedTarget)
        {
            return _targets.Value.Get(entity).entity.Unpack(_world.Value, out unpackedTarget);
        }

        public bool IsTargetAlive(in int entity)
        {
            return IsTargetExist(entity, out var target) && _healthUseCase.Value.Exists(target);
        }

        public bool IsTargetInAttackDistance(in int entity)
        {
            return GetDistance(entity) <= _attackDistances.Value.Get(entity).value;
        }

        public float GetDistance(in int entity)
        {
            ref var target = ref _targets.Value.Get(entity);
            target.entity.Unpack(_world.Value, out int targetEntity);
            ref var selfPosition = ref _positions.Value.Get(entity);
            ref var targetPosition = ref _positions.Value.Get(targetEntity);

            return math.distance(selfPosition.value, targetPosition.value);
        }

        public float3 GetDirection(in int entity)
        {
            ref var target = ref _targets.Value.Get(entity);
            target.entity.Unpack(_world.Value, out int targetEntity);
            ref var selfPosition = ref _positions.Value.Get(entity);
            ref var targetPosition = ref _positions.Value.Get(targetEntity);

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

        public bool HasTarget(int entity)
        {
            return _targets.Value.Has(entity);
        }
    }
}