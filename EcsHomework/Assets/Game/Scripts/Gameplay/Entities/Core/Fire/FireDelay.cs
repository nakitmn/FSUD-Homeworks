using System;

namespace SampleGame
{
    [Serializable]
    public struct FireDelay
    {
        public bool enabled;
        public float duration;
        public float current;
    }
}