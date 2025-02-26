using UnityEngine;

namespace Game.Gameplay
{
    public sealed class JumpComponent
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;

        public JumpComponent(Rigidbody2D rigidbody, float jumpForce)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
        }
        
        public void Jump()
        {
            var force = Vector2.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}