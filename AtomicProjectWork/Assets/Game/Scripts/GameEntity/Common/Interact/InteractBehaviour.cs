using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class InteractBehaviour : IInit<IGameEntity>, IDispose
    {
        private TriggerEventReceiver _trigger;
        private IGameEntity _entity;
        
        public void Init(IGameEntity entity)
        {
            _entity = entity;
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            InteractUseCase.Interact(_entity, collider);
        }
    }
}