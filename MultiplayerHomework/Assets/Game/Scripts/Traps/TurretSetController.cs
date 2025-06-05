using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    public sealed class TurretSetController : NetworkBehaviour
    {
        [SerializeField] private NetworkPrefabRef _prefab;
        [SerializeField] private InputReceiver _inputReceiver;
        [SerializeField] private int _price;
        
        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public override void Spawned()
        {
            _inputReceiver.OnTurret += TryPlace;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _inputReceiver.OnTurret -= TryPlace;
        }

        private void TryPlace()
        {
            if (HasStateAuthority == false)
            {
                return;
            }

            if (_moneyStorage.Spend(_price))
            {
                Runner.Spawn(_prefab, transform.position, transform.rotation);
            }
        }
    }
}