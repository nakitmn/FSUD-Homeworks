using Atomic.Elements;
using UnityEngine;

namespace SampleGame
{
    public abstract class TemporaryEffectConfig : EffectConfig
    {
        [field: SerializeField]
        public Const<float> Duration { get; private set; }
    }
    
    
    
}