using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class ResourceBagSerializer : EntityComponentSerializer<ResourceBagSerializer.Data, ResourceBag>
    {
        protected override Data CreateData(ResourceBag resourceBag)
        {
            return new()
            {
                Type = resourceBag.Type,
                Current = resourceBag.Current
            };
        }

        protected override void ApplyData(ResourceBag resourceBag, Data data)
        {
            resourceBag.Type = data.Type;
            resourceBag.Current = data.Current;
        }
        
        [Serializable]
        public struct Data
        {
            public ResourceType Type { get; set; }
            public int Current { get; set; }
        }
    }
}