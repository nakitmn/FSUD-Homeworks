using System;
using Leopotam.EcsLite;

namespace SampleGame
{
    [Serializable]
    public struct DeadEvent
    {
        public EcsPackedEntity entity;
    }
}