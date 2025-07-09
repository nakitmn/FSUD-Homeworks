using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public abstract class AbilityConfig : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        public Ability Create(IEntity entity)
        {
            var ability = new Ability(Name);
            ability.SetIcon(Icon);
            Install(ability, entity);
            return ability;
        }

        protected abstract void Install(Ability ability, IEntity entity);
    }
}