using UnityEngine;

namespace Space_Ship.Components
{
    public class MoveComponent
    {
        private Rigidbody2D _rigidbody;
        private float _speed;

        public MoveComponent(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            Vector2 moveStep = direction * _speed;
            Vector2 targetPosition = _rigidbody.position + moveStep;
            _rigidbody.MovePosition(targetPosition);
        }
    }
}