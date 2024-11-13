using System.Linq;
using Bullets;
using Common;
using Space_Ship;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyFacade : MonoBehaviour
    {
        private const int PREWARM_POOL_COUNT = 7;
        
        [SerializeField] private SpaceShip _player;
        [SerializeField] private BulletFacade _bulletFacade;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private MonoPool<Enemy> _enemyPool;

        private EnemyFactory _enemyFactory;

        private void Awake()
        {
            _enemyPool.Prewarm(PREWARM_POOL_COUNT);

            _enemyFactory = new EnemyFactory(_enemyPool, _player, _bulletFacade);

            _enemySpawner.Construct(_enemyFactory);
        }

        private void Start()
        {
            _enemySpawner.EnableSpawning();
        }

        private void FixedUpdate()
        {
            DestroyDiedEnemies();
        }

        private void DestroyDiedEnemies()
        {
            foreach (Enemy enemy in _enemyFactory.ActiveEnemies.ToArray())
            {
                if (enemy.IsDead)
                {
                    _enemyFactory.Despawn(enemy);
                }
            }
        }
    }
}