using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.TeamSpawner;

namespace SampleGame
{
    public sealed class DisableSpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TeamSpawnerTag, SpawningEnabled>> _teamSpawners;
        private readonly EcsPoolInject<CastleTag> _castles;
        private readonly EcsEventInject<DeadEvent> _deadEvent;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            while (_deadEvent.Value.Consume(out var deadEvent))
            {
                if (deadEvent.entity.Unpack(_world.Value, out var entity) == false)
                {
                    continue;
                }

                if (_castles.Value.Has(entity) == false)
                {
                    continue;
                }

                foreach (var spawnerEntity in _teamSpawners.Value)
                {
                    _teamSpawners.Pools.Inc2.Del(spawnerEntity);
                }
            }
        }
    }
}