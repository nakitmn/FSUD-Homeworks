using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public static class EffectUseCase
    {
        public static bool CanApply(in IEntity character, in EffectConfig effect)
        {
            IReactiveDictionary<string, EffectInstance> effects = character.GetEffects();
            return effect.CanApply(character) && !effects.ContainsKey(effect.Name);
        }

        public static bool Apply(in IEntity character, in EffectConfig effect)
        {
            if (character.HasEffects() == false)
            {
                return false;
            }
            
            string effectName = effect.Name;
            
            IReactiveDictionary<string, EffectInstance> effects = character.GetEffects();
            if (effects.ContainsKey(effectName) || !effect.Apply(character, out EffectInstance instance))
                return false;
            
            effects.Add(effectName, instance);
            return true;
        }

        public static bool Discard(in IEntity character, in string effectName)
        {
            IReactiveDictionary<string, EffectInstance> effects = character.GetEffects();
            if (!effects.Remove(effectName, out EffectInstance instance))
                return false;

            instance.Dispose();
            return true;
        }

        public static bool DiscardAll(in IEntity character)
        {
            var effects = character.GetEffects();
            if (effects.Count == 0)
                return false;

            foreach (var (key, effectInstance) in effects)
            {
                effectInstance.Dispose();
            }

            effects.Clear();
            return true;
        }
    }
}