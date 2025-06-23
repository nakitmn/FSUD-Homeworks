using Fusion;
using UnityEngine;

namespace Game
{
    public class ProjectileView : MonoBehaviour
    {
        public ProjectileType Type => _config.Type;

        [SerializeField]
        private ProjectileConfig _config;

        public virtual void OnSpawn(
            in ProjectileState projectile,
            in NetworkRunner runner,
            in PlayerRef player,
            in float renderTime
        )
        {
            this.UpdateTransform(in projectile, in runner, in renderTime);
        }

        public virtual void OnUpdate(
            in ProjectileState projectile,
            in NetworkRunner runner,
            in PlayerRef player,
            in float renderTime
        )
        {
            this.UpdateTransform(in projectile, in runner, in renderTime);
        }

        public virtual void OnUnspawn(in NetworkRunner runner, in PlayerRef player)
        {
        }

        private void UpdateTransform(in ProjectileState projectile, in NetworkRunner runner, in float renderTime)
        {
            float time = renderTime - projectile.tick * runner.DeltaTime;
            Vector3 position = _config.GetPosition(in projectile, in time);
            Quaternion rotation = _config.GetRotation(in projectile, in time);
            this.transform.SetPositionAndRotation(position, rotation);
        }
    }
}