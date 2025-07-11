using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public static class EffectUseCase
    {
        public static bool CanApply(in IGameEntity character, in EffectConfig effect)
        {
            IReactiveDictionary<string, Effect> effects = character.GetEffects();
            return effect.CanApply(character) && !effects.ContainsKey(effect.Name);
        }

        public static bool Apply(in IGameEntity character, in EffectConfig effect)
        {
            if (character.HasEffects() == false)
            {
                return false;
            }
            
            string effectName = effect.Name;
            
            IReactiveDictionary<string, Effect> effects = character.GetEffects();
            if (effects.ContainsKey(effectName) || !effect.Apply(character, out Effect instance))
                return false;
            
            effects.Add(effectName, instance);
            return true;
        }

        public static bool Discard(in IGameEntity character, in string effectName)
        {
            IReactiveDictionary<string, Effect> effects = character.GetEffects();
            if (!effects.Remove(effectName, out Effect instance))
                return false;

            instance.Dispose();
            return true;
        }

        public static bool DiscardAll(in IGameEntity character)
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