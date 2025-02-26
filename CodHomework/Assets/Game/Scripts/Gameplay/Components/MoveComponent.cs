using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class MoveComponent : IFixedTickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly AndCondition _canMoveCondition = new();

        private Vector2 _direction;

        public MoveComponent(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        void IFixedTickable.FixedTick()
        {
            if (_canMoveCondition.IsTrue() == false)
            {
                return;
            }
            
            var velocity = _direction * _speed;
            _rigidbody.AddForce(velocity, ForceMode2D.Force);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void AddCondition(Func<bool> condition)
        {
            _canMoveCondition.AddCondition(condition);
        }
    }
}