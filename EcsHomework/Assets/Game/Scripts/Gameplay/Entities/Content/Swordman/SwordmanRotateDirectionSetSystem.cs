using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;
using Unity.Mathematics;

namespace SampleGame
{
    public sealed class SwordmanRotateDirectionSetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SwordmanTag>> _characters;
        private readonly EcsPoolInject<UnitRotateDirection> _rotateDirections;
        private readonly EcsPoolInject<UnitMoveDirection> _moveDirections;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var rotateDirection = ref _rotateDirections.Value.Get(entity);

                if (_targetUseCase.Value.HasTarget(entity) == false)
                {
                    rotateDirection.value = float3.zero;
                    continue;
                }

                if (_targetUseCase.Value.IsTargetInAttackDistance(entity))
                {
                    rotateDirection.value = _targetUseCase.Value.GetDirection(entity);
                }
                else
                {
                    rotateDirection.value = _moveDirections.Value.Get(entity).value;
                }
            }
        }
    }
}