using System;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class JumpComponent
    {
        public event Action OnJump;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;
        
        private readonly AndCondition _canJumpCondition = new();
        
        public JumpComponent(Rigidbody2D rigidbody, float jumpForce)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
        }
        
        public void Jump()
        {
            if (_canJumpCondition.IsTrue() == false)
            {
                return;
            }
            
            var force = Vector2.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
            
            OnJump?.Invoke();
        }
        
        public void AddCondition(Func<bool> condition)
        {
            _canJumpCondition.AddCondition(condition);
        }
    }
}