using Leopotam.EcsLite;
using SampleGame.TeamSpawner;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "TeamSpawner",
        menuName = "SampleGame/Entities/New TeamSpawner"
    )]
    public sealed class TeamSpawnerPrototype : EcsPrototype
    {
        [SerializeField] private EcsPrototype[] _unitsToSpawn;
        [SerializeField] private float _spawnCooldown = 3f;
        [SerializeField] private TeamType _team;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<NonViewTag>().Add(entity);
            world.GetPool<TeamSpawnerTag>().Add(entity);
            world.GetPool<SpawningEnabled>().Add(entity);
            world.GetPool<PrototypesCatalog>().Add(entity).value = _unitsToSpawn;
            world.GetPool<TeamType>().Add(entity) = _team;
            world.GetPool<Cooldown>().Add(entity) = new Cooldown()
            {
                duration = _spawnCooldown,
                current = _spawnCooldown
            };
        }
    }
}