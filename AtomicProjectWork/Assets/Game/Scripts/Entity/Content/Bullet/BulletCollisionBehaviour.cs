using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class BulletCollisionBehaviour : IInit, IDispose
    {
        private IAction _destroyAction;
        private TriggerEventReceiver _trigger;
        private IValue<int> _damage;
        private IValue<IEntity> _owner;
        private EffectConfig[] _projectileEffects;

        public void Init(in IEntity entity)
        {
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();
            _owner = entity.GetOwner();
            _projectileEffects = entity.GetProjectileEffects();

            _trigger = entity.GetTrigger();
            _trigger.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            var damage = TakeDamageUseCase.GetExtraDamage(_damage.Value, _owner.Value);
            var owner = _owner.Value;

            if (collider.TryGetComponent(out IEntity target) && TakeDamageUseCase.TakeDamage(target, damage, owner))
            {
                Array.ForEach(_projectileEffects, effect => EffectUseCase.Apply(target, effect));
                _destroyAction.Invoke();
            }
        }
    }
}