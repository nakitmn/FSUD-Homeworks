using System.Collections.Generic;
using Bullets.Interfaces;
using Common;
using Level;
using UnityEngine;

namespace Bullets
{
    public sealed class BulletFacade : MonoBehaviour, IBulletFactory
    {
        private const int PREWARM_POOL_COUNT = 10;
        
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private MonoPool<Bullet> _bulletPool;

        private readonly List<Bullet> _cache = new();

        private BulletFactory _bulletFactory;

        private void Awake()
        {
            _bulletPool.Prewarm(PREWARM_POOL_COUNT);
            _bulletFactory = new BulletFactory(_bulletPool);
        }

        private void FixedUpdate()
        {
            DespawnOutOfBoundsBullets();
        }

        public Bullet SpawnBullet(BulletParams bulletParams)
        {
            Bullet bullet = _bulletFactory.SpawnBullet(bulletParams);
            bullet.OnCollisionEntered += OnBulletCollision;
            return bullet;
        }

        public void Despawn(Bullet bullet)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            _bulletFactory.Despawn(bullet);
        }
        
        private void DespawnOutOfBoundsBullets()
        {
            _cache.Clear();
            _cache.AddRange(_bulletFactory.ActiveBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                Bullet bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    Despawn(bullet);
                }
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            Despawn(bullet);
        }
    }
}