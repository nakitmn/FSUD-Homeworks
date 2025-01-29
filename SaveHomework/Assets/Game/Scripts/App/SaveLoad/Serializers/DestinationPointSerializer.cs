using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class DestinationPointSerializer : EntityComponentSerializer<DestinationPointData, DestinationPoint>
    {
        protected override DestinationPointData CreateData(DestinationPoint destinationPoint)
        {
            return new() {Value = Vector3Data.FromVector3(destinationPoint.Value)};
        }

        protected override void ApplyData(DestinationPoint destinationPoint, DestinationPointData data)
        {
            destinationPoint.Value = Vector3Data.ToVector3(data.Value);
        }
    }
}