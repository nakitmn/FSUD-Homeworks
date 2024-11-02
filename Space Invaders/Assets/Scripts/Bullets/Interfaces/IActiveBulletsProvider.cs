using System.Collections.Generic;

namespace Bullets.Interfaces
{
    public interface IActiveBulletsProvider
    {
        IEnumerable<Bullet> ActiveBullets { get; }
    }
}