using System.Collections.Generic;

namespace Homework
{
    public class ConvertInstruction
    {
        public IResource InputResource { get; }
        public int InputConvertCount { get; }
        public IResource OutputResource { get; }
        public int OutputConvertCount { get; }
        public float ConvertDuration { get; }

        public ConvertInstruction(IResource inputResource,
            int inputConvertCount,
            IResource outputResource,
            int outputConvertCount,
            float convertDuration
        )
        {
            InputResource = inputResource;
            InputConvertCount = inputConvertCount;
            OutputResource = outputResource;
            OutputConvertCount = outputConvertCount;
            ConvertDuration = convertDuration;
        }

        public ConvertInstruction(
            KeyValuePair<IResource, int> inputResource,
            KeyValuePair<IResource, int> outputResource,
            float convertDuration
        )
        {
            InputResource = inputResource.Key;
            InputConvertCount = inputResource.Value;
            OutputResource = outputResource.Key;
            OutputConvertCount = outputResource.Value;
            ConvertDuration = convertDuration;
        }
    }
}