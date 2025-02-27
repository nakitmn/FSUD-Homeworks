using System;
using System.Collections.Generic;
using Modules.Entity;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class PushOutComponent : IInitializable
    {
        public event Action OnPushed;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _cooldown;
        private readonly float _force;

        private readonly PushComponent _pushComponent;
        private readonly ReloadComponent _reloadComponent;
        private readonly AndCondition _conditions = new();

        public PushOutComponent(Rigidbody2D rigidbody, float cooldown, float force)
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
        }

        public void AddCondition(Func<bool> condition)
        {
            _conditions.AddCondition(condition);
        }

        public void Push(IEnumerable<IEntity> entities)
        {
            if (_conditions.IsTrue() == false)
            {
                return;
            }

            foreach (var entity in entities)
            {
                PushInternal(entity);
            }

            _reloadComponent.Reload();
            
            OnPushed?.Invoke();
        }

        public void Push(IEntity entity)
        {
            if (_conditions.IsTrue() == false)
            {
                return;
            }

            PushInternal(entity);
            _reloadComponent.Reload();

            OnPushed?.Invoke();
        }

        private void PushInternal(IEntity entity)
        {
            if (entity.TryGet<Rigidbody2D>(out var rigidbody) == false)
            {
                return;
            }
            
            var direction = rigidbody.position - _rigidbody.position;
            direction.x = Mathf.Sign(direction.x);
            direction.y = 0f;
            _pushComponent.Push(rigidbody, direction, _force);
        }
    }
}