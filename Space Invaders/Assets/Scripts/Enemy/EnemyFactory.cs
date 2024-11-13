using System.Collections.Generic;
using Bullets;
using Bullets.Interfaces;
using Common;
using Enemy.Interfaces;
using Space_Ship;

namespace Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly MonoPool<Enemy> _enemyPool;
        private readonly SpaceShip _player;
        private readonly IBulletFactory _bulletFactory;

        private readonly HashSet<Enemy> _activeEnemies = new();

        public IEnumerable<Enemy> ActiveEnemies => _activeEnemies;

        public EnemyFactory(MonoPool<Enemy> enemyPool, SpaceShip player, IBulletFactory bulletFactory)
        {
            _enemyPool = enemyPool;
            _player = player;
            _bulletFactory = bulletFactory;
        }

        public Enemy Create()
        {
            Enemy enemy = _enemyPool.Get();
            enemy.Construct(_player, _bulletFactory);
            _activeEnemies.Add(enemy);
            return enemy;
        }

        public void Despawn(Enemy enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                _enemyPool.Enqueue(enemy);
            }
        }
    }
}