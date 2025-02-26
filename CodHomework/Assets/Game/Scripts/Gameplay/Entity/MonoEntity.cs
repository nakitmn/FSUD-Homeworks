using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    [RequireComponent(typeof(GameObjectContext))]
    public abstract class MonoEntity : MonoBehaviour, IEntity
    {
        private readonly Dictionary<Type, object> _cachedComponents = new();
        private GameObjectContext _context;

        private void Awake()
        {
            _context = GetComponent<GameObjectContext>();
        }

        public T Get<T>()
        {
            var componentType = typeof(T);
            if (_cachedComponents.TryGetValue(componentType, out var cachedComponent))
            {
                return (T) cachedComponent;
            }

            var component = _context.Container.Resolve<T>();
            _cachedComponents[componentType] = component;
            return component;
        }

        public bool TryGet<T>(out T component)
        {
            var componentType = typeof(T);
            if (_cachedComponents.TryGetValue(componentType, out var cachedComponent))
            {
                component = (T) cachedComponent;
                return true;
            }

            var resolveComponent = _context.Container.TryResolve(componentType);
            if (resolveComponent == null)
            {
                component = default;
                return false;
            }

            component = (T) resolveComponent;
            _cachedComponents[componentType] = component;
            return true;
        }
    }
}