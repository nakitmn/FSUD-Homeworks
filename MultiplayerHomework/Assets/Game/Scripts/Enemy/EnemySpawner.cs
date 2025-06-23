using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    public sealed class EnemySpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject _portal;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private int _count;
        [SerializeField] private float _spawnCooldown;

        [Networked] public bool CanSpawn { get; private set; }
        [Networked] private TickTimer _spawnTimer { get; set; }
        [Networked] private int _spawnedCount { get; set; }

        private SpawnPointService _spawnPointService;

        [Inject]
        public void Construct(SpawnPointService spawnPointService)
        {
            _spawnPointService = spawnPointService;
        }
        
        public void StartSpawn()
        {
            CanSpawn = true;
        }

        public override void FixedUpdateNetwork()
        {
            if (CanSpawn == false)
            {
                return;
            }

            if (_spawnedCount >= _count)
            {
                return;
            }

            if (_spawnTimer.ExpiredOrNotRunning(Runner))
            {
                Spawn();
                _spawnedCount++;
                
                if (_spawnedCount < _count)
                {
                    _spawnTimer = TickTimer.CreateFromSeconds(Runner, _spawnCooldown);
                }
            }
        }

        private void Spawn()
        {
            var spawnPoint = _spawnPointService.GetRandomSpawnPoint();
            Runner.Spawn(_enemyConfig.Prefab, spawnPoint.position, spawnPoint.rotation, onBeforeSpawned: OnEnemySpawned);
        }

        private void OnEnemySpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            networkObject.GetComponent<Enemy>().Init(_portal);
        }
    }
}