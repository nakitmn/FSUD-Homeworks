using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;

namespace SampleGame
{
    public sealed class UnitSelectTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            var units = _units.Value;
            foreach (int entity in units)
            {
                if (_targetUseCase.Value.HasTarget(entity))
                {
                    if (_targetUseCase.Value.IsTargetExist(entity, out _) 
                        && _targetUseCase.Value.IsTargetAlive(entity)
                        )
                    {
                        continue;
                    }
        
                    _targets.Value.Del(entity);
                }

                if (_targetUseCase.Value.GetClosest(entity, units, out var targetEntity))
                {
                    _targets.Value.Add(entity).entity = _world.Value.PackEntity(targetEntity);
                }
            }
        }
    }
}