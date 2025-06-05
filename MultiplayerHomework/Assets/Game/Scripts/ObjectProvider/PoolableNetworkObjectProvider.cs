using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class PoolableNetworkObjectProvider : NetworkObjectProviderDefault
    {
        [SerializeField]
        private PoolableNetworkObjectCatalog _catalog;

        [SerializeField]
        private Transform _container;

        private Dictionary<NetworkObject, Queue<NetworkObject>> _pool;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        private void Awake()
        {
            IReadOnlyList<NetworkObject> prefabs = _catalog.Prefabs;
            int count = prefabs.Count;

            _pool = new Dictionary<NetworkObject, Queue<NetworkObject>>(count);
            for (int i = 0; i < count; i++)
            {
                NetworkObject prefab = prefabs[i];
                _pool.Add(prefab, new Queue<NetworkObject>());
            }
        }

        protected override NetworkObject InstantiatePrefab(NetworkRunner runner, NetworkObject prefab)
        {
            if (!_catalog.ContainsPrefab(prefab))
            {
                var networkObject = base.InstantiatePrefab(runner, prefab);
                _diContainer.InjectGameObject(networkObject.gameObject);
                return networkObject;
            }

            Queue<NetworkObject> queue = _pool[prefab];
            if (queue.TryDequeue(out NetworkObject instance))
            {
                instance.gameObject.SetActive(true);
            }
            else
            {
                instance = Instantiate(prefab);
                _diContainer.InjectGameObject(instance.gameObject);
            }

            instance.name = prefab.name;
            return instance;
        }

        protected override void DestroyPrefabInstance(
            NetworkRunner runner,
            NetworkPrefabId prefabId,
            NetworkObject instance
        )
        {
            if (!_catalog.FindPrefab(instance.name, out NetworkObject prefab))
            {
                base.DestroyPrefabInstance(runner, prefabId, instance);
                return;
            }

            Queue<NetworkObject> queue = _pool[prefab];
            queue.Enqueue(instance);

            instance.gameObject.SetActive(false);
            instance.transform.parent = _container;
        }
    }
}