using System.Collections.Generic;

namespace Enemy.Interfaces
{
    public interface IActiveEnemiesProvider
    {
        IEnumerable<Enemy> ActiveEnemies { get; }
    }
}