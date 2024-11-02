using UnityEngine;

namespace Bullets
{
    [CreateAssetMenu(menuName = GameConstants.CONFIGS_ROOT + "Bullet", order = 0)]
    public class BulletConfig : ScriptableObject
    {
        public Color Color;
        public int Damage;
        public float Speed;
        public int PhysicsLayer;
    }
}