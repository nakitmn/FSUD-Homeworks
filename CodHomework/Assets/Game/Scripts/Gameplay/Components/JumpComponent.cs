using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class JumpComponent : IInitializable
    {
        public event Action OnJumped
        {
            add => _pushComponent.OnPushed += value;
            remove => _pushComponent.OnPushed -= value;
        }
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _cooldown;
        private readonly float _force;

        private readonly PushComponent _pushComponent;
        private readonly ReloadComponent _reloadComponent;

        public JumpComponent(Rigidbody2D rigidbody, float cooldown, float force)
        {
            _rigidbody = rigidbody;
            _cooldown = cooldown;
            _force = force;

            _pushComponent = new PushComponent();
            _reloadComponent = new ReloadComponent(_cooldown);
        }

        void IInitializable.Initialize()
        {
            AddCondition(_reloadComponent.IsReady);

            _pushComponent.OnPushed += _reloadComponent.Reload;
        }

        public void AddCondition(Func<bool> condition)
        {
            _pushComponent.AddCondition(condition);
        }

        public void Jump()
        {
            _pushComponent.Push(_rigidbody, Vector2.up, _force);
        }
    }
}