using System.Collections.Generic;
using Modules.Entities;

namespace SampleGame.App
{
    public abstract class EntityComponentSerializer<TData, TComponent> : GameSerializer<EntityWorld, Dictionary<int, TData>>
    {
        protected override string Key => $"{typeof(TComponent).Name}{typeof(TData).Name}";

        protected override Dictionary<int, TData> Serialize(EntityWorld world)
        {
            var entities = world.GetAll();
            var componentDatas = new Dictionary<int, TData>();

            foreach (var entity in entities)
            {
                var component = entity.GetComponent<TComponent>();

                if (component == null)
                {
                    continue;
                }

                componentDatas.Add(entity.Id, CreateData(component));
            }

            return componentDatas;
        }

        protected override void Deserialize(EntityWorld world, Dictionary<int, TData> componentDatas)
        {
            foreach (var (entityId, data) in componentDatas)
            {
                if (world.Has(entityId) == false)
                {
                    continue;
                }

                var entity = world.Get(entityId);

                var component = entity.GetComponent<TComponent>();
                if (component == null)
                {
                    continue;
                }

                ApplyData(component, data);
            }
        }

        protected abstract TData CreateData(TComponent component);
        protected abstract void ApplyData(TComponent component, TData data);
    }
}