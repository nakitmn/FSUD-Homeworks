using System;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class TargetObjectSerializer : EntityComponentSerializer<TargetObjectSerializer.Data, TargetObject>
    {
        protected override Data CreateData(TargetObject targetObject)
        {
            if (targetObject.Value == null)
            {
                return new();
            }

            return new() {EntityId = targetObject.Value.Id};
        }

        protected override void ApplyData(TargetObject targetObject, Data data)
        {
            var entityId = data.EntityId;
            
            if (Service.Has(entityId))
            {
                targetObject.Value = Service.Get(entityId);
            }
        }
        
        [Serializable]
        public struct Data
        {
            public int EntityId;
        }
    }
}