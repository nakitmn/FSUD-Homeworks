using Bullets.Interfaces;
using Enemy.Agents;
using Space_Ship;
using UnityEngine;

namespace Enemy
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private SpaceShip _selfShip;
        [SerializeField] private EnemyAttackAgent _attackAgent;
        [SerializeField] private EnemyMoveAgent _moveAgent;

        public bool IsDead => _selfShip.IsDead;

        public void Construct(SpaceShip target, IBulletFactory bulletFactory)
        {
            _selfShip.Construct(_shipConfig, bulletFactory);
            _moveAgent.Construct(_selfShip);
            _attackAgent.Construct(_selfShip, target);
        }

        private void OnEnable()
        {
            _moveAgent.OnDestinated += OnDestinated;
        }

        private void OnDisable()
        {
            _moveAgent.OnDestinated -= OnDestinated;
            _attackAgent.Disable();
        }

        public void SetDestination(Vector2 endPoint)
        {
            _moveAgent.SetDestination(endPoint);
        }

        private void OnDestinated()
        {
            _attackAgent.Enable();
        }
    }
}