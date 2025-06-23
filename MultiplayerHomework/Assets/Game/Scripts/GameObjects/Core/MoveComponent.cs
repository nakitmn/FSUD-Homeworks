using System;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MoveComponent : NetworkBehaviour
    {
        public event Action<bool> OnMoveStateChanged;

        [SerializeField] private float _speed = 5;

        private Func<bool> _condition;

        [Networked, OnChangedRender(nameof(InvokeMoveStateChanged))]
        public bool IsMoving { get; set; }

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

        private void InvokeMoveStateChanged()
        {
            OnMoveStateChanged?.Invoke(IsMoving);
        }
    }
}