using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace SampleGame
{
    public sealed class EffectAreaBehaviour : IInit, IDispose
    {
        private readonly IEntityAspect _effect;
        private TriggerEventReceiver _trigger;

        public EffectAreaBehaviour(IEntityAspect effect)
        {
            _effect = effect;
        }

        public void Init(in IEntity entity)
        {
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += this.OnTriggerEntered;
            _trigger.OnExited += this.OnTriggerExited;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= this.OnTriggerEntered;
            _trigger.OnExited -= this.OnTriggerExited;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity entity))
                _effect.Apply(entity);
        }

        private void OnTriggerExited(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity entity))
                _effect.Discard(entity);
        }
    }
}