using System;
using System.Collections.Generic;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.App
{
    public sealed class
        EntitySerializer : GameSerializer<EntityWorld, IEnumerable<IEntityComponentSerializer>, EntitySerializer.Data[]>
    {
        protected override string Key => $"{nameof(EntitySerializer)}{nameof(Data)})";

        protected override Data[] Serialize(EntityWorld world,
            IEnumerable<IEntityComponentSerializer> componentSerializers)
        {
            var entities = world.GetAll();
            var entityDatas = new Data[entities.Count];
            var index = 0;

            foreach (var entity in entities)
            {
                var data = new Data()
                {
                    Name = entity.Name,
                    Id = entity.Id,
                    TransformData = TransformData.FromTransform(entity.transform),
                    Components = SerializeComponents(entity, componentSerializers)
                };

                entityDatas[index++] = data;
            }

            return entityDatas;
        }

        protected override void Deserialize(EntityWorld world,
            IEnumerable<IEntityComponentSerializer> componentSerializers, Data[] data)
        {
            world.DestroyAll();

            foreach (var entityData in data)
            {
                world.Spawn(
                    entityData.Name,
                    Vector3Data.ToVector3(entityData.TransformData.Position),
                    Quaternion.Euler(Vector3Data.ToVector3(entityData.TransformData.Rotation)),
                    entityData.Id
                );
            }

            // Если десериализовать компонеты сразу со спауном, то в некоторых случаях не будет работать
            // TargetObjectSerializer и подобные ему компоненты, которые ссылаются на другие Entity
            foreach (var entityData in data)
            {
                var entity = world.Get(entityData.Id);
                DeserializeComponents(entity, componentSerializers, entityData.Components);
            }
        }

        private Dictionary<string, string> SerializeComponents(Entity entity,
            IEnumerable<IEntityComponentSerializer> componentSerializers)
        {
            var componentsData = new Dictionary<string, string>();

            foreach (var serializer in componentSerializers)
            {
                serializer.SerializeComponent(entity, componentsData);
            }

            return componentsData;
        }

        private void DeserializeComponents(Entity entity, IEnumerable<IEntityComponentSerializer> componentSerializers,
            Dictionary<string, string> componentsData)
        {
            foreach (var serializer in componentSerializers)
            {
                serializer.DeserializeComponent(entity, componentsData);
            }
        }
        
        [Serializable]
        public struct Data
        {
            public string Name;
            public int Id;
            public TransformData TransformData;
            public Dictionary<string, string> Components;
        }
    }
}