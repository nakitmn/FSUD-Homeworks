using System;
using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        private const string MOVEMNT_AXIS = "Horizontal";
        
        public event Action OnFireRequired;

        public float MoveDirection { get; private set; }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireRequired?.Invoke();
            }

            MoveDirection = Input.GetAxisRaw(MOVEMNT_AXIS);
        }
    }
}