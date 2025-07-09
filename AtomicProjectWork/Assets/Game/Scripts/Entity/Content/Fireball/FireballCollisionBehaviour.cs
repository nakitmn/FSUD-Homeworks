using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class FireballCollisionBehaviour : IInit, IDispose
    {
        private IAction _destroyAction;
        private TriggerEventReceiver _trigger;
        private IValue<int> _damage;
        private IValue<IEntity> _owner;
        private IValue<float> _damageRadius;
        private Transform _transform;

        public void Init(in IEntity entity)
        {
            _transform = entity.GetTransform();
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();
            _owner = entity.GetOwner();
            _damageRadius = entity.GetDamageRadius();

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
            
            if (collider.TryGetComponent(out IEntity target) && owner != null && target.Id == owner.Id)
                return;
            
            TakeDamageUseCase.TakePointDamage(_transform.position, _damageRadius.Value,damage, owner);
            
            _destroyAction.Invoke();
        }
    }
}