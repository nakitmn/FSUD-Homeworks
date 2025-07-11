using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class TakeDamageAnimBehaviour : IInit<IGameEntity>, IDispose
    {
        private readonly int _takeDamageHash;
        
        private Animator _animator;
        private IEvent _damagedEvent;

        public TakeDamageAnimBehaviour(string takeDamageHash)
        {
            _takeDamageHash = Animator.StringToHash(takeDamageHash);
        }

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            _damagedEvent = entity.GetDamagedEvent();
            _damagedEvent.Subscribe(OnDamaged);
        }

        public void Dispose(in IEntity entity)
        {
            _damagedEvent.Unsubscribe(OnDamaged);
        }

        private void OnDamaged()
        {
            _animator.SetTrigger(_takeDamageHash);
        }
    }
}