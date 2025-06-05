using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileWorld : NetworkBehaviour
    {
        private const int MAX_PROJECTILES = 8;

        [SerializeField]
        private ProjectileCatalog _catalog;

        [Networked, Capacity(MAX_PROJECTILES)]
        private NetworkArray<ProjectileState> _projectiles { get; }

        public int Length => MAX_PROJECTILES;

        public IEnumerable<ProjectileState> Projectiles => _projectiles;

        public bool Spawn(ProjectileType type, Vector3 position, Quaternion rotation)
        {
            if (!this.FindFreeSlot(out int index))
                return false;

            ProjectileState projectile = new ProjectileState
            {
                type = type,
                tick = this.Runner.Tick,
                position = position,
                rotation = rotation
            };

            _projectiles.Set(index, projectile);
            return true;
        }

        public ProjectileState GetProjectile(int index)
        {
            return _projectiles[index];
        }

        public override void FixedUpdateNetwork()
        {
            NetworkRunner runner = this.Runner;
            PlayerRef player = this.Object.InputAuthority;

            for (int i = 0; i < _projectiles.Length; i++)
            {
                ref ProjectileState projectile = ref _projectiles.GetRef(i);
                if (!projectile.IsActive)
                    continue;

                ProjectileType type = projectile.type;
                ProjectileConfig config = _catalog.GetConfig(type);

                if (!config.SimulateStep(in projectile, in runner, in player))
                    projectile.SetInactive();
            }
        }

        private bool FindFreeSlot(out int index)
        {
            for (int i = 0; i < _projectiles.Length; i++)
            {
                ProjectileState projectile = _projectiles[i];
                if (!projectile.IsActive)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        private void OnDrawGizmos()
        {
            if (!this.StateBufferIsValid)
                return;

            NetworkRunner runner = this.Runner;
            PlayerRef player = this.Object.InputAuthority;

            for (int i = 0; i < _projectiles.Length; i++)
            {
                ref ProjectileState projectile = ref _projectiles.GetRef(i);
                if (projectile.IsActive)
                {
                    ProjectileType type = projectile.type;
                    ProjectileConfig config = _catalog.GetConfig(type);
                    config.DrawGizmos(in projectile, in runner, in player);
                }
            }
        }
    }
}