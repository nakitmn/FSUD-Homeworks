using System;
using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public class AbilityAutoSelectBehaviour : IInit, IEnable
    {
        private readonly AbilityConfig[] _sortedAbilities;

        private IReactiveVariable<Ability> _selectedAbility;
        private IReactiveDictionary<string, Ability> _abilities;

        public AbilityAutoSelectBehaviour(AbilityConfig[] sortedAbilities)
        {
            _sortedAbilities = sortedAbilities;
        }

        public void Init(in IEntity entity)
        {
            _abilities = entity.GetAbilities();
            _selectedAbility = entity.GetSelectedAbility();
            _selectedAbility.Subscribe(OnSelectedAbilityChanged);
        }

        public void Enable(in IEntity entity)
        {
            SelectNextAbility();
        }

        private void OnSelectedAbilityChanged(Ability ability)
        {
            var charges = ability.GetCharges();
            charges.Subscribe(OnChargesChanged);
        }

        private void OnChargesChanged(int charges)
        {
            if (charges == 0)
            {
                SelectNextAbility();
            }
        }

        private void SelectNextAbility()
        {
            var selectedAbility = _selectedAbility.Value;
            var selectedAbilityIndex =
                Array.FindIndex(_sortedAbilities, ability => ability.Name == selectedAbility.Name);
            
            for (var i = _sortedAbilities.Length - 1; i >= 0; i--)
            {
                if (i == selectedAbilityIndex)
                {
                    continue;
                }

                var abilityConfig = _sortedAbilities[i];
                var ability = _abilities[abilityConfig.Name];
                if (ability.GetCharges().Value > 0)
                {
                    ChangeSelectedAbility(ability);
                    return;
                }
            }
        }

        private void ChangeSelectedAbility(Ability ability)
        {
            _selectedAbility.Value.GetCharges().Unsubscribe(OnChargesChanged);
            _selectedAbility.Value = ability;
        }
    }
}