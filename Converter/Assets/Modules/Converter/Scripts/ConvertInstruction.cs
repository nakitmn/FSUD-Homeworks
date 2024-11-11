namespace Homework
{
    public class ConvertInstruction
    {
        public IResource InputResource { get; }
        public IResource OutputResource { get; }
        public float ConvertDuration { get; }

        public ConvertInstruction(IResource inputResource, IResource outputResource, float convertDuration)
        {
            InputResource = inputResource;
            OutputResource = outputResource;
            ConvertDuration = convertDuration;
        }
    }
}