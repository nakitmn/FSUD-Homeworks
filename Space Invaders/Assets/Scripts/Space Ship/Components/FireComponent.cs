using Bullets;
using Bullets.Interfaces;
using UnityEngine;

namespace Space_Ship.Components
{
    public class FireComponent
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly BulletConfig _config;
        private readonly Transform _firePoint;

        public FireComponent(IBulletFactory bulletFactory, BulletConfig config, Transform firePoint)
        {
            _bulletFactory = bulletFactory;
            _config = config;
            _firePoint = firePoint;
        }

        public void FireTo(Vector2 position)
        {
            Vector2 startPosition = _firePoint.position;
            Vector2 vector = position - startPosition;
            Vector2 direction = vector.normalized;
            Fire(direction);
        }
        
        public void Fire(Vector2 direction)
        {
            _bulletFactory.SpawnBullet(new()
            {
                Position = _firePoint.position,
                Color = _config.Color,
                Damage = _config.Damage,
                PhysicsLayer = _config.PhysicsLayer,
                Velocity = direction * _config.Speed,
            });
        }
    }
}