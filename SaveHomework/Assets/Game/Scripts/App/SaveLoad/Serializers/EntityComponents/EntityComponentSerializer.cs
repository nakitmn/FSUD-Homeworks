using System.Collections.Generic;
using Modules.Entities;
using Newtonsoft.Json;
using UnityEngine;

namespace SampleGame.App
{
    public abstract class EntityComponentSerializer<TData, TComponent> : IEntityComponentSerializer where TComponent : Component
    {
        protected virtual string Key => typeof(TComponent).Name;

        public bool SerializeComponent(Entity entity, Dictionary<string, string> componentsData)
        {
            if (entity.TryGetComponent(typeof(TComponent), out Component component))
            {
                if (component is TComponent castedComponent)
                {
                    var data = CreateData(castedComponent);
                    var json = JsonConvert.SerializeObject(data);
                    componentsData[Key] = json;
                    return true;
                }
            }

            return false;
        }

        public bool DeserializeComponent(Entity entity, Dictionary<string, string> componentsData)
        {
            if (componentsData.TryGetValue(Key, out string json) == false)
            {
                return false;
            }

            if (entity.TryGetComponent(typeof(TComponent), out Component component) == false)
            {
                return false;
            }

            if (component is TComponent castedComponent == false)
            {
                return false;
            }
            
            var deserializeObject = JsonConvert.DeserializeObject(json,typeof(TData));
            if (deserializeObject == null)
            {
                return false;
            }

            ApplyData(castedComponent, (TData)deserializeObject);
            return true;
        }

        protected abstract TData CreateData(TComponent component);
        protected abstract void ApplyData(TComponent component, TData data);
    }
}