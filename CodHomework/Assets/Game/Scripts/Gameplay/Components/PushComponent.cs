using System;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PushComponent
    {
        public event Action OnPushed;
        
        private readonly AndCondition _canPushCondition = new();
        
        public void Push(Rigidbody2D rigidbody, Vector2 direction, float force)
        {
            if (_canPushCondition.IsTrue() == false)
            {
                return;
            }
            
            var forceDirection = direction * force;
            rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
            
            OnPushed?.Invoke();
        }

        public void AddCondition(Func<bool> condition)
        {
            _canPushCondition.AddCondition(condition);
        }
    }
}