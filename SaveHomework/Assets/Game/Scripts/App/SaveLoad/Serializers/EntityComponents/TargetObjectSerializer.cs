using System;
using Modules.Entities;
using SampleGame.Gameplay;
using Zenject;

namespace SampleGame.App
{
    public sealed class TargetObjectSerializer : EntityComponentSerializer<TargetObjectSerializer.Data, TargetObject>
    {
        [Inject] private EntityWorld _world;
        
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
            
            if (_world.Has(entityId))
            {
                targetObject.Value = _world.Get(entityId);
            }
        }
        
        [Serializable]
        public struct Data
        {
            public int EntityId;
        }
    }
}