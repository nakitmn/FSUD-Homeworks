using System.Linq;
using Enemy.Interfaces;

namespace Enemy.Controllers
{
    public sealed class DiedEnemiesDestroyController
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IActiveEnemiesProvider _activeEnemiesProvider;

        public DiedEnemiesDestroyController(IEnemyFactory enemyFactory, IActiveEnemiesProvider activeEnemiesProvider)
        {
            _enemyFactory = enemyFactory;
            _activeEnemiesProvider = activeEnemiesProvider;
        }

        public void Update()
        {
            foreach (Enemy enemy in _activeEnemiesProvider.ActiveEnemies.ToArray())
            {
                if (enemy.IsDead)
                {
                    _enemyFactory.Despawn(enemy);
                }
            }
        }
    }
}