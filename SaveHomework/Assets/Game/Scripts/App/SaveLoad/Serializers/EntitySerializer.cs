using Modules.Entities;
using UnityEngine;

namespace SampleGame.App
{
    public sealed class EntitySerializer : GameSerializer<EntityWorld, EntityData[]>
    {
        protected override EntityData[] Serialize(EntityWorld world)
        {
            var entities = world.GetAll();
            var entityDatas = new EntityData[entities.Count];
            var index = 0;

            foreach (var entity in entities)
            {
                var data = new EntityData()
                {
                    Name = entity.Name,
                    Id = entity.Id,
                    TransformData = TransformData.FromTransform(entity.transform)
                };

                entityDatas[index++] = data;
            }

            return entityDatas;
        }

        protected override void Deserialize(EntityWorld world, EntityData[] data)
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
        }
    }
}