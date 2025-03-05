using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;

namespace SampleGame
{
    public sealed class ArcherFireSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArcherTag>> _characters;
        private readonly EcsPoolInject<UnitFireRequired> _fireRequired;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var fireRequired = ref _fireRequired.Value.Get(entity);

                fireRequired.value = _targetUseCase.Value.HasTarget(entity) 
                                     && _targetUseCase.Value.IsTargetInAttackDistance(entity);
            }
        }
    }
}