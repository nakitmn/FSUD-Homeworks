using System;
using Fusion;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class TrapSpawner : NetworkBehaviour
    {
        [SerializeField] private InputReceiver _inputReceiver;
        [SerializeField] private TrapSpawnConfig[] _configs;

        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public override void Spawned()
        {
            _inputReceiver.OnKeyPressed += TryPlace;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _inputReceiver.OnKeyPressed -= TryPlace;
        }

        private void TryPlace(PlayerKeys pressedKey)
        {
            if (HasStateAuthority == false)
            {
                return;
            }

            foreach (var config in _configs)
            {
                if (config.key != pressedKey)
                {
                    continue;
                }

                if (_moneyStorage.Spend(config.price))
                {
                    Runner.Spawn(config.prefab, transform.position, transform.rotation);
                }
            }
        }

        [Serializable]
        private class TrapSpawnConfig
        {
            public NetworkPrefabRef prefab;
            public PlayerKeys key;
            public int price;
        }
    }
}