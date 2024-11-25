using System.Collections.Generic;

namespace Homework
{
    public class ConvertInstruction<TResource>
    {
        public TResource InputResource { get; }
        public int InputConvertCount { get; }
        public TResource OutputResource { get; }
        public int OutputConvertCount { get; }
        public float ConvertDuration { get; }

        public ConvertInstruction(TResource inputResource,
            int inputConvertCount,
            TResource outputResource,
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
            KeyValuePair<TResource, int> inputResource,
            KeyValuePair<TResource, int> outputResource,
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