using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "ProjectileCatalog",
        menuName = "Game/Projectiles/New Catalog"
    )]
    public sealed class ProjectileCatalog : ScriptableObject
    {
        public IReadOnlyList<ProjectileConfig> AllConfigs => _configs;

        [SerializeField]
        private ProjectileConfig[] _configs;

        public ProjectileConfig GetConfig(ProjectileType type)
        {
            for (int i = 0, count = _configs.Length; i < count; i++)
            {
                ProjectileConfig config = _configs[i];
                if (config.Type == type)
                    return config;
            }

            throw new Exception($"Projectile config of type {type} is not found!");
        }
    }
}