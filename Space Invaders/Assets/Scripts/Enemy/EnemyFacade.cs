using Bullets;
using Common;
using Enemy.Controllers;
using Space_Ship;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public sealed class EnemyFacade : MonoBehaviour
    {
        private const int PREWARM_POOL_COUNT = 7;
        
        [SerializeField] private SpaceShip _player;
        [SerializeField] private BulletFacade _bulletFacade;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private MonoPool<Enemy> _enemyPool;

        private DiedEnemiesDestroyController _diedEnemiesDestroyController;
        private EnemyFactory _enemyFactory;

        private void Awake()
        {
            _enemyPool.Prewarm(PREWARM_POOL_COUNT);

            _enemyFactory = new EnemyFactory(_enemyPool, _player, _bulletFacade);
            _diedEnemiesDestroyController = new DiedEnemiesDestroyController(_enemyFactory, _enemyFactory);

            _enemySpawner.Construct(_enemyFactory);
        }

        private void Start()
        {
            _enemySpawner.EnableSpawning();
        }

        private void FixedUpdate()
        {
            _diedEnemiesDestroyController.Update();
        }
    }
}