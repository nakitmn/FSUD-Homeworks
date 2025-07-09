using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class TakeDamageAnimBehaviour : IInit, IDispose
    {
        private readonly int _takeDamageHash;
        
        private Animator _animator;

        public TakeDamageAnimBehaviour(string takeDamageHash)
        {
            _takeDamageHash = Animator.StringToHash(takeDamageHash);
        }

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetDamagedEvent().Subscribe(OnDamaged);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetDamagedEvent().Unsubscribe(OnDamaged);
        }

        private void OnDamaged()
        {
            _animator.SetTrigger(_takeDamageHash);
        }
    }
}