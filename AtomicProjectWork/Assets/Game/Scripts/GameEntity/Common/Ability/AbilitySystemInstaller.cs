using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class AbilitySystemInstaller : IEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private AbilityConfig[] _abilities;

        public void Install(IGameEntity entity)
        {
            var abilities = CreateAbilities(entity);
            var selectedAbility = abilities[_abilities[0].Name];
            
            entity.AddAbilities(abilities);
            entity.AddSelectedAbility(new ReactiveVariable<Ability>(selectedAbility));
            
            entity.AddBehaviour<AbilityRunner>();
            entity.AddBehaviour(new AbilityAutoSelectBehaviour(_abilities));
        }

        private ReactiveDictionary<string, Ability> CreateAbilities(IGameEntity entity)
        {
            int length = _abilities.Length;
            var result = new ReactiveDictionary<string, Ability>(length);
            for (int i = 0; i < length; i++)
            {
                AbilityConfig config = _abilities[i];
                Ability ability = config.Create(entity);
                result.Add(ability.Name, ability);
            }
            
            return result;
        }
    }
}
