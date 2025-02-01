using System;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class DestinationPointSerializer : EntityComponentSerializer<DestinationPointSerializer.Data, DestinationPoint>
    {
        protected override Data CreateData(DestinationPoint destinationPoint)
        {
            return new() {Value = Vector3Data.FromVector3(destinationPoint.Value)};
        }

        protected override void ApplyData(DestinationPoint destinationPoint, Data data)
        {
            destinationPoint.Value = Vector3Data.ToVector3(data.Value);
        }
        
        [Serializable]
        public struct Data
        {
            public Vector3Data Value;
        }
    }
}