using System.Linq;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class SpawnerStartController : NetworkBehaviour
    {
        [SerializeField] private EnemySpawner _spawner;

        public override void FixedUpdateNetwork()
        {
            if (_spawner.CanSpawn)
            {
                return;
            }

            if (Runner.ActivePlayers.Count() >= 2)
            {
                _spawner.StartSpawn();
            }
        }
    }
}