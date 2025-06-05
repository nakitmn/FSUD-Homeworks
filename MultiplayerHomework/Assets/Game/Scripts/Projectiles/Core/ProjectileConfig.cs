using Fusion;
using UnityEngine;

namespace Game
{
    public abstract class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField]
        public ProjectileType Type { get; private set; }
        
        [field: SerializeField]
        public ProjectileView Prefab { get; private set; }
        
        public abstract bool SimulateStep(in ProjectileState projectile, in NetworkRunner runner, in PlayerRef player);

        public abstract void DrawGizmos(in ProjectileState projectile, in NetworkRunner runner, in PlayerRef player);
        
        public abstract Vector3 GetPosition(in ProjectileState projectile, in float time);
        
        public abstract Quaternion GetRotation(in ProjectileState projectile, in float time);
    }
}