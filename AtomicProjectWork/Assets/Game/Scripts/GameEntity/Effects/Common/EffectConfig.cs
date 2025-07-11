using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public abstract class EffectConfig : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public string Description { get; private set; }
        
        [field: SerializeField]
        public Sprite Icon { get; private set; }

        [Button]
        public bool Apply(in IGameEntity target, out Effect instance)
        {
            instance = this.CanApply(target) ? this.Create(target) : null;
            return instance != null;
        }
        
        [Button]
        public abstract bool CanApply(in IGameEntity target);

        protected abstract Effect Create(in IGameEntity target);
    }
}