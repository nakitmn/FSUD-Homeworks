using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;
using Unity.Mathematics;

namespace SampleGame
{
    public sealed class ArcherMoveDirectionSetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArcherTag>> _characters;
        private readonly EcsPoolInject<UnitMoveDirection> _directions;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var direction = ref _directions.Value.Get(entity);

                if (_targetUseCase.Value.HasTarget(entity) == false
                    || _targetUseCase.Value.IsTargetInAttackDistance(entity)
                   )
                {
                    direction.value = float3.zero;
                    continue;
                }

                direction.value = _targetUseCase.Value.GetDirection(entity);
            }
        }
    }
}