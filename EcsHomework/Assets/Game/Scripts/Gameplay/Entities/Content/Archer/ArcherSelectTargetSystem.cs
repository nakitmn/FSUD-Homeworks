using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;
using Unity.Mathematics;

namespace SampleGame
{
    public sealed class ArcherSelectTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArcherTag>> _characters;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                if (_targets.Value.Has(entity))
                {
                    if (_targetUseCase.Value.IsTargetAlive(entity))
                    {
                        continue;
                    }

                    _targets.Value.Del(entity);
                }

                if (_targetUseCase.Value.GetClosest(entity, _characters.Value, out var targetEntity))
                {
                    _targets.Value.Add(entity).entity = targetEntity;
                }
            }
        }
    }
}