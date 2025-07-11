using System;
using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class AbilityPresenter
    {
        private readonly AbilityView _view;
        private readonly Ability _ability;
        private readonly IGameEntity _entity;
        private IReactiveVariable<Ability> _selectedAbility;
        private IReactiveVariable<int> _charges;
        private Cooldown _cooldown;

        public bool IsVisible => _view.gameObject.activeInHierarchy;

        public AbilityPresenter(AbilityView view, Ability ability, IGameEntity entity)
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
            
            if (_ability.HasCooldown())
            {
                _cooldown = _ability.GetCooldown();
                _cooldown.OnTick += OnCooldownTick;
            }

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
            
            if (_cooldown != null)
            {
                _cooldown.OnTick -= OnCooldownTick;
            }
        }

        private void OnCooldownTick()
        {
            _view.SetCooldownActive(_cooldown.IsExpired() == false);
            _view.SetCooldownProgress(_cooldown.GetProgress());
            _view.SetRemainCooldownValue($"{_cooldown.Current:N1}");
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
            _entity.GetSelectAbilityAction().Invoke(_ability);
        }
    }
}