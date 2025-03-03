using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;

namespace SampleGame
{
    public sealed class ArcherFireTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArcherTag, Target>> _characters;
        private readonly EcsPoolInject<UnitAttackDistance> _attackDistances;
        private readonly EcsPoolInject<UnitFireRequired> _fireRequired;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var attackDistance = ref _attackDistances.Value.Get(entity);
                ref var fireRequired = ref _fireRequired.Value.Get(entity);

                fireRequired.value = _targetUseCase.Value.GetDistance(entity) <= attackDistance.value;
            }
        }
    }
}