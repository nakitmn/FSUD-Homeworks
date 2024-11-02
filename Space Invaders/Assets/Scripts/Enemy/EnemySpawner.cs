using System.Collections;
using Common;
using Enemy.Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;
        
        private IEnemyFactory _enemyFactory;

        public void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void EnableSpawning()
        {
            StartCoroutine(SpawnRoutine());
        }
        
        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                Enemy enemy = _enemyFactory.Create(); 

                Transform spawnPosition = _spawnPositions.Random();
                enemy.transform.position = spawnPosition.position;

                Transform attackPosition = _attackPositions.Random();
                enemy.SetDestination(attackPosition.position);
            }
        }
    }
}