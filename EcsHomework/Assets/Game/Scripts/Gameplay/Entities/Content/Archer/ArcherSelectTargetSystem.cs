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
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsFilterInject<Inc<TeamType>> _teams;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                ref var entityPosition = ref _positions.Value.Get(entity);
                ref var entityTeam = ref _teams.Pools.Inc1.Get(entity);

                var closest = float.MaxValue;

                foreach (var targetEntity in _teams.Value)
                {
                    ref var targetEntityPosition = ref _positions.Value.Get(targetEntity);
                    ref var targetEntityTeam = ref _teams.Pools.Inc1.Get(targetEntity);

                    if (targetEntityTeam == entityTeam)
                    {
                        continue;
                    }

                    var distance = math.distance(targetEntityPosition.value, entityPosition.value);
                    if (distance < closest)
                    {
                        if (_targets.Value.Has(entity))
                        {
                            _targets.Value.Get(entity).entity = targetEntity;
                        }
                        else
                        {
                            _targets.Value.Add(entity).entity = targetEntity;
                        }
                        
                        closest = distance;
                    }
                }
            }
        }
    }
}