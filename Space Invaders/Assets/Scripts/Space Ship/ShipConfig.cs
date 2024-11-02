using Bullets;
using UnityEngine;

namespace Space_Ship
{
    [CreateAssetMenu(menuName = GameConstants.CONFIGS_ROOT + "Ship", order = 0)]
    public class ShipConfig : ScriptableObject
    {
        public int Health;
        public float Speed;
        public BulletConfig BulletConfig;
    }
}