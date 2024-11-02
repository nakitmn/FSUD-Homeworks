using System;
using System.Collections.Generic;
using Bullets.Interfaces;
using Level;

namespace Bullets.Controllers
{
    public class BulletBoundsController
    {
        public event Action<Bullet> OnBulletOutOfBounds; 
        
        private readonly IActiveBulletsProvider _activeBulletsProvider;
        private readonly LevelBounds _levelBounds;

        private readonly List<Bullet> _cache = new();

        public BulletBoundsController(
            IActiveBulletsProvider activeBulletsProvider,
            LevelBounds levelBounds)
        {
            _activeBulletsProvider = activeBulletsProvider;
            _levelBounds = levelBounds;
        }

        public void OnUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBulletsProvider.ActiveBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                Bullet bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    OnBulletOutOfBounds?.Invoke(bullet);
                }
            }
        }
    }
}