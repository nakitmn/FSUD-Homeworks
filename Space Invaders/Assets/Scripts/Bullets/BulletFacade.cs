using Bullets.Controllers;
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

        private BulletBoundsController _bulletBoundsController;
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            _bulletPool.Prewarm(PREWARM_POOL_COUNT);
            _bulletFactory = new BulletFactory(_bulletPool);
            _bulletBoundsController = new BulletBoundsController(_bulletFactory, _levelBounds);
        }

        private void OnEnable()
        {
            _bulletBoundsController.OnBulletOutOfBounds += OnBulletOutOfBounds;
        }

        private void OnDisable()
        {
            _bulletBoundsController.OnBulletOutOfBounds -= OnBulletOutOfBounds;
        }

        private void FixedUpdate()
        {
            _bulletBoundsController.OnUpdate();
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

        private void OnBulletOutOfBounds(Bullet bullet)
        {
            Despawn(bullet);
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            Despawn(bullet);
        }
    }
}