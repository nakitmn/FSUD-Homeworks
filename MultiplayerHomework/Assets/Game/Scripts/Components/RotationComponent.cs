using System;
using UnityEngine;

namespace Game
{
    public sealed class RotationComponent : MonoBehaviour
    {
        [SerializeField] private float _speedRate;

        private Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public bool CanRotate()
        {
            return _condition == null || _condition.Invoke();
        }

        public void RotateStep(Vector3 direction, float deltaTime)
        {
            if (CanRotate() == false)
            {
                return;
            }

            if (direction == Vector3.zero)
            {
                return;
            }
            
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(direction),
                _speedRate * deltaTime
            );
        }
    }
}