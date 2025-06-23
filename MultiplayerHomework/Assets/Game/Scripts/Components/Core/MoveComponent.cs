using System;
using UnityEngine;

namespace Game
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;

        private Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }
        
        public void MoveStep(Vector3 direction, float deltaTime)
        {
            if (_condition?.Invoke() == false)
            {
                return;
            }

            transform.position += direction * (_speed * deltaTime);
        }
    }
}