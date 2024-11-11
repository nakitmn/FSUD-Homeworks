using System;
using Space_Ship;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action OnDestinated;

        public bool IsReached { get; private set; } = true;

        [SerializeField] private float _stopDistance = 0.25f;
        
        private SpaceShip _ship;
        private Vector2 _destination;

        public void Construct(SpaceShip ship)
        {
            _ship = ship;
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
            enabled = true;
        }

        private void FixedUpdate()
        {
            if (IsReached)
            {
                enabled = false;
                return;
            }

            Vector2 toDestination = _destination - _ship.Position;
            if (toDestination.magnitude <= _stopDistance)
            {
                IsReached = true;
                OnDestinated?.Invoke();
                enabled = false;
                return;
            }

            Vector2 velocity = toDestination.normalized * Time.fixedDeltaTime;
            _ship.Move(velocity);
        }
    }
}