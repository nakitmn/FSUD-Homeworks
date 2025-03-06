using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame.TeamSpawner
{
    public sealed class TeamSpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TeamSpawnerTag>> _spawners;
        private readonly EcsPoolInject<SpawningEnabled> _spawningEnabled;
        private readonly EcsPoolInject<PrototypesCatalog> _prototypesCatalog;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<Cooldown> _cooldowns;
        private readonly EcsEventInject<SpawnRequest> _spawnRequest;
        private readonly EcsCustomInject<SceneData> _sceneData;

        public void Run(IEcsSystems systems)
        {
            var spawnPoints = _sceneData.Value.redSpawnPoints;
            
            foreach (var entity in _spawners.Value)
            {
                ref var cooldown = ref _cooldowns.Value.Get(entity);
                ref var prototypesCatalog = ref _prototypesCatalog.Value.Get(entity);
                ref var teamType = ref _teamTypes.Value.Get(entity);
                
                if (_spawningEnabled.Value.Has(entity) == false)
                {
                    return;
                }
                
                if (cooldown.current > 0f)
                {
                    continue;
                }
                
                cooldown.current = cooldown.duration;
                
                var spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
                var prototypes = prototypesCatalog.value;
                var prefab = prototypes[Random.Range(0,prototypes.Length)];

                _spawnRequest.Value.Fire(new SpawnRequest
                {
                    prefab = prefab,
                    position = spawnPoint.position,
                    rotation = spawnPoint.rotation,
                    team = teamType
                });
            }
        }
    }
}