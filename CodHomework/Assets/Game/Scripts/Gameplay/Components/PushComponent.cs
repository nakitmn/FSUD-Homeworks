using System;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PushComponent
    {
        public event Action OnPushed;
        
        private readonly Vector2 _direction;
        private readonly float _force;
        
        private readonly AndCondition _canPushCondition = new();

        public PushComponent(Vector2 direction, float force)
        {
            _direction = direction;
            _force = force;
        }

        public void Push(Rigidbody2D rigidbody)
        {
            if (_canPushCondition.IsTrue() == false)
            {
                return;
            }
            
            var force = _direction * _force;
            rigidbody.AddForce(force, ForceMode2D.Impulse);
            
            OnPushed?.Invoke();
        }
        
        public void AddCondition(Func<bool> condition)
        {
            _canPushCondition.AddCondition(condition);
        }
    }
}