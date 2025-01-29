using System;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class HealthSerializer : EntityComponentSerializer<HealthSerializer.Data, Health>
    {
        protected override Data CreateData(Health health)
        {
            return new() {Current = health.Current};
        }

        protected override void ApplyData(Health health, Data data)
        {
            health.Current = data.Current;
        }
        
        [Serializable]
        public struct Data
        {
            public int Current;
        }
    }
}