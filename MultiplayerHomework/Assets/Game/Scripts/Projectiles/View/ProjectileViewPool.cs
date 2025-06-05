using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileViewPool : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private ProjectileCatalog _catalog;

        private Dictionary<ProjectileType, Pool> _pools;

        private void Awake()
        {
            IReadOnlyList<ProjectileConfig> configs = _catalog.AllConfigs;
            int count = configs.Count;
         
            _pools = new Dictionary<ProjectileType, Pool>(count);
            for (int i = 0; i < count; i++)
            {
                ProjectileConfig config = configs[i];
                _pools.Add(config.Type, new Pool(config.Prefab));
            }
        }

        public ProjectileView Rent(in ProjectileType type, in Transform parent)
        {
            Pool pool = _pools[type];
            return pool.Rent(in parent);
        }

        public void Return(in ProjectileView view)
        {
            Pool pool = _pools[view.Type];
            view.transform.parent = _container;
            pool.Return(in view);
        }

        private sealed class Pool
        {
            private readonly ProjectileView _prefab;
            private readonly Stack<ProjectileView> _stack = new();

            public Pool(ProjectileView prefab)
            {
                _prefab = prefab;
            }

            public ProjectileView Rent(in Transform parent)
            {
                if (_stack.TryPop(out ProjectileView view))
                {
                    view.gameObject.SetActive(true);
                    view.transform.parent = parent;
                    return view;
                }

                view = Instantiate(_prefab, parent);
                view.name = _prefab.name;
                return view;
            }

            public void Return(in ProjectileView view)
            {
                view.gameObject.SetActive(false);
                
                if (!_stack.Contains(view))
                    _stack.Push(view);
                else
                    Debug.LogWarning($"View {view.Type} already contains in pool!", view);
            }
        }
    }
}