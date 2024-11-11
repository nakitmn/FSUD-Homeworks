using System;
using Bullets;
using Bullets.Interfaces;
using Common.Interfaces;
using Space_Ship.Components;
using UnityEngine;

namespace Space_Ship
{
    public sealed class SpaceShip : MonoBehaviour, IDamagable
    {
        public event Action OnDeath
        {
            add => _healthComponent.OnHealthEmpty += value;
            remove => _healthComponent.OnHealthEmpty -= value;
        }

        [SerializeField] private Transform _firePoint;
        [SerializeField] private Rigidbody2D _rigidbody;

        public bool IsDead => _healthComponent.IsDead;
        public Vector2 FireForward => _firePoint.up;

        private MoveComponent _moveComponent;
        private HealthComponent _healthComponent;
        private FireComponent _fireComponent;

        public void Construct(ShipConfig shipConfig, IBulletFactory bulletFactory)
        {
            _moveComponent = new MoveComponent(_rigidbody, shipConfig.Speed);
            _healthComponent = new HealthComponent(shipConfig.Health);
            _fireComponent = new FireComponent(bulletFactory, shipConfig.BulletConfig, _firePoint);
        }

        public void Move(Vector2 direction)
        {
            _moveComponent.Move(direction);
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        public void FireTo(Vector2 position)
        {
            _fireComponent.FireTo(position);
        }
        
        public void Fire(Vector2 direction)
        {
            _fireComponent.Fire(direction);
        }
    }
}