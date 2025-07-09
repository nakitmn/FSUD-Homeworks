using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class AbilityPickUpInstaller : SceneEntityInstaller
    {
        [SerializeField] private AbilityConfig _abilityConfig;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private int _charges;

        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);

            entity.AddInteractibleTag();
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                IReadOnlyDictionary<string, Ability> abilities = character.GetAbilities();
                if (abilities.TryGetValue(_abilityConfig.Name, out Ability ability))
                {
                    ability.GetCharges().Value += _charges;
                    gameContext.GetEntityPool().Return(entity);
                }
            }));

            _name.text = _abilityConfig.Name;
        }
    }
}