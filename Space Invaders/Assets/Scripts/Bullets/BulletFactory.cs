using System.Collections.Generic;
using Bullets.Interfaces;
using Common;

namespace Bullets
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly MonoPool<Bullet> _bulletPool;

        private readonly HashSet<Bullet> _activeBullets = new();

        public IEnumerable<Bullet> ActiveBullets => _activeBullets;

        public BulletFactory(MonoPool<Bullet> bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public Bullet SpawnBullet(BulletParams bulletParams)
        {
            Bullet bullet = _bulletPool.Get();
            bullet.SetParams(bulletParams);
            _activeBullets.Add(bullet);
            return bullet;
        }

        public void Despawn(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                _bulletPool.Enqueue(bullet);
            }
        }
    }
}