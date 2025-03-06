using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame.PurchaseUnit
{
    public sealed class PurchaseUnitSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<PurchaseUnitRequest> _purchaseRequests;
        private readonly EcsEventInject<SpawnRequest> _spawnRequest;
        private readonly EcsSingletonInject<PlayerData> _playerData;
        private readonly EcsCustomInject<SceneData> _sceneData;

        public void Run(IEcsSystems systems)
        {
            var spawnPoints = _sceneData.Value.blueSpawnPoints;

            while (_purchaseRequests.Value.Consume(out var request))
            {
                var unitCardConfig = request.config;
                
                if (_playerData.Value.money < unitCardConfig.Price)
                {
                    continue;
                }

                _playerData.Value.money -= unitCardConfig.Price;
                
                var spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
                var prefab = unitCardConfig.Prefab;

                _spawnRequest.Value.Fire(new SpawnRequest
                {
                    prefab = prefab,
                    position = spawnPoint.position,
                    rotation = spawnPoint.rotation,
                    team = TeamType.BLUE
                });
            }
        }
    }
}