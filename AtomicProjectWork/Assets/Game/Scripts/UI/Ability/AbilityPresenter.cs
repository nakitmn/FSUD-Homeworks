using System;
using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class AbilityPresenter
    {
        private readonly AbilityView _view;
        private readonly Ability _ability;
        private readonly IEntity _entity;
        private IReactiveVariable<Ability> _selectedAbility;
        private IReactiveVariable<int> _charges;

        public bool IsVisible => _view.gameObject.activeInHierarchy;

        public AbilityPresenter(AbilityView view, Ability ability, IEntity entity)
        {
            _view = view;
            _ability = ability;
            _entity = entity;
        }

        public void Enable()
        {
            _selectedAbility = _entity.GetSelectedAbility();
            _charges = _ability.GetCharges();
            
            _view.SetIcon(_ability.GetIcon());
            _view.SetName(_ability.Name);
            _view.gameObject.SetActive(true);
            
            _view.OnSelectClicked += Select;
            _selectedAbility.Observe(OnSelectedChanged);
            _charges.Observe(OnCountChanged);
        }

        public void Disable()
        {
            _view.gameObject.SetActive(false);
            _view.OnSelectClicked -= Select;
            _selectedAbility.Unsubscribe(OnSelectedChanged);
            _charges.Unsubscribe(OnCountChanged);
        }

        private void OnCountChanged(int count)
        {
            _view.SetCount(count.ToString());
        }

        private void OnSelectedChanged(Ability ability)
        {
            _view.SetSelected(ability == _ability);
        }

        public void Select()
        {
            _selectedAbility.Value = _ability;
        }
    }
}