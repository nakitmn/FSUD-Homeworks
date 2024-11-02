using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    [Serializable]
    public class MonoPool<T> where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _container;
        
        public readonly Queue<T> _pool = new();

        public void Prewarm(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                T obj = Create();
                Enqueue(obj);
            }
        }

        public void Enqueue(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }

        public T Get()
        {
            if (_pool.TryDequeue(out var obj))
            {
                obj.gameObject.SetActive(true);
                return obj;
            }

            return Create();
        }

        private T Create()
        {
            return Object.Instantiate(_prefab, _container);
        }
    }
}