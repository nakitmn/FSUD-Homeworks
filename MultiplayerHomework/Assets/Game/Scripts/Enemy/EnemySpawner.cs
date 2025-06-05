using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class EnemySpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject _portal;
        [SerializeField] private SpawnPointService _spawnPointService;
        [SerializeField] private NetworkPrefabRef _enemyPrefab;
        [SerializeField] private int _count;
        [SerializeField] private float _spawnCooldown;

        [Networked] public bool CanSpawn { get; private set; }
        [Networked] private TickTimer _spawnTimer { get; set; }
        [Networked] private int _spawnedCount { get; set; }

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
            Runner.Spawn(_enemyPrefab, spawnPoint.position, spawnPoint.rotation, onBeforeSpawned: OnEnemySpawned);
        }

        private void OnEnemySpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            networkObject.GetComponent<Enemy>().Init(_portal);
        }
    }
}