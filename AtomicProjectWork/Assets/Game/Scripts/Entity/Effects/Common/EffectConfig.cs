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
        public bool Apply(in IEntity target, out EffectInstance instance)
        {
            instance = this.CanApply(target) ? this.Create(target) : null;
            return instance != null;
        }
        
        [Button]
        public abstract bool CanApply(in IEntity target);

        protected abstract EffectInstance Create(in IEntity target);
    }
}