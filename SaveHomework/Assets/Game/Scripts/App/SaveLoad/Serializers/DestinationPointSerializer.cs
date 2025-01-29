using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class DestinationPointSerializer : GameSerializer<EntityWorld, DestinationPointData[]>
    {
        protected override DestinationPointData[] Serialize(EntityWorld world)
        {
            var entities = world.GetAll();
            var datas = new List<DestinationPointData>();

            foreach (var entity in entities)
            {
                var destinationPoint = entity.GetComponent<DestinationPoint>();

                if (destinationPoint == null)
                {
                    continue;
                }

                var data = new DestinationPointData()
                {
                    EntityId = entity.Id,
                    Value = Vector3Data.FromVector3(destinationPoint.Value)
                };

                datas.Add(data);
            }

            return datas.ToArray();
        }

        protected override void Deserialize(EntityWorld world, DestinationPointData[] datas)
        {
            foreach (var data in datas)
            {
                if (world.Has(data.EntityId) == false)
                {
                    continue;
                }

                var entity = world.Get(data.EntityId);

                var destinationPoint = entity.GetComponent<DestinationPoint>();
                if (destinationPoint == null)
                {
                    continue;
                }

                destinationPoint.Value = Vector3Data.ToVector3(data.Value);
            }
        }
    }
}