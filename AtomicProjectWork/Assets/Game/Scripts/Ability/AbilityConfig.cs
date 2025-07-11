using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public abstract class AbilityConfig : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        [field: SerializeField]
        public GameObject ClickEffectPrefab { get; private set; }
        
        public Ability Create(IGameEntity entity)
        {
            var ability = new Ability(Name);
            ability.SetIcon(Icon);
            ability.SetClickEffectPrefab(new Const<GameObject>(ClickEffectPrefab));
            Install(ability, entity);
            return ability;
        }

        protected abstract void Install(Ability ability, IGameEntity entity);
    }
}