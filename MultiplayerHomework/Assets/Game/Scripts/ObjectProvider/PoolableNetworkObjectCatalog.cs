using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "PoolableNetworkObjectCatalog",
        menuName = "Game/New PoolableNetworkObjectCatalog"
    )]
    public sealed class PoolableNetworkObjectCatalog : ScriptableObject
    {
        public IReadOnlyList<NetworkObject> Prefabs => _prefabs;

        [SerializeField]
        private List<NetworkObject> _prefabs;

        public bool ContainsPrefab(NetworkObject prefab)
        {
            return _prefabs.Contains(prefab);
        }

        public bool FindPrefab(string prefabName, out NetworkObject prefab)
        {
            for (int i = 0, count = _prefabs.Count; i < count; i++)
            {
                prefab = _prefabs[i];
                if (prefab.name == prefabName)
                    return true;
            }

            prefab = default;
            return false;
        }
    }
}