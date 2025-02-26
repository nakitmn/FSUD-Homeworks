using System;
using System.Collections.Generic;
using Modules.Entity;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class PushUpComponent : IInitializable
    {
        private readonly float _cooldown;
        private readonly float _force;

        private readonly PushComponent _pushComponent;
        private readonly ReloadComponent _reloadComponent;
        private readonly AndCondition _conditions = new();

        public PushUpComponent(float cooldown, float force)
        {
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

        public void Push(List<IEntity> entities)
        {
            if (_conditions.IsTrue() == false)
            {
                return;
            }

            foreach (var entity in entities)
            {
                if (entity.TryGet<Rigidbody2D>(out var rigidbody))
                {
                    _pushComponent.Push(rigidbody, Vector2.up, _force);
                }
            }

            _reloadComponent.Reload();
        }
    }
}