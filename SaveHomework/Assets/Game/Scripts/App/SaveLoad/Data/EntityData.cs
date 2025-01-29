using System;

namespace SampleGame.App
{
    [Serializable]
    public struct EntityData
    {
        public string Name;
        public int Id;
        public TransformData TransformData;
    }
}