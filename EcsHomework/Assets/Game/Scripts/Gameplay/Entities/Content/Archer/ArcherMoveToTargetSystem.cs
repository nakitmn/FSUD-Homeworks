using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;
using Unity.Mathematics;

namespace SampleGame
{
    public sealed class ArcherMoveToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArcherTag, Target>> _characters;
        private readonly EcsPoolInject<UnitDirection> _directions;
        private readonly EcsPoolInject<UnitAttackDistance> _attackDistances;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var attackDistance = ref _attackDistances.Value.Get(entity);
                ref var direction = ref _directions.Value.Get(entity);

                if (_targetUseCase.Value.GetDistance(entity) <= attackDistance.value)
                {
                    direction.value = float3.zero;
                    continue;
                }
                
                direction.value = _targetUseCase.Value.GetDirection(entity);
            }
        }
    }
}