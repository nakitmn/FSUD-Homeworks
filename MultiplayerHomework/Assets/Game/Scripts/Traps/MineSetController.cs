using Fusion;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class MineSetController : NetworkBehaviour
    {
        [SerializeField] private NetworkPrefabRef _minePrefab;
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
            _inputReceiver.OnMine += TryPlace;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _inputReceiver.OnMine -= TryPlace;
        }

        private void TryPlace()
        {
            if (HasStateAuthority == false)
            {
                return;
            }

            if (_moneyStorage.Spend(_price))
            {
                Runner.Spawn(_minePrefab, transform.position, transform.rotation);
            }
        }
    }
}