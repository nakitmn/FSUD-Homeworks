using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "EcsSystems",
        menuName = "SampleGame/New EcsSystems"
    )]
    public sealed class EcsSystemsFactory : ScriptableObject
    {
        [SerializeField]
        private TeamViewConfig _teamViewConfig;

        [SerializeField]
        private EcsPrototype _projectilePrefab;

        [SerializeField]
        private int _initialMoney = 100;
        
        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();
            world.AddSingleton(new PlayerData{money = _initialMoney});
            
            EcsSystems systems = new EcsSystems(world);
            
            systems.AddWorld(new EcsWorld(), EcsConsts.EventWorld);
            systems
                //Game Logic
                .Add(new SpawnSystem())
                .Add(new LifetimeSystem())
                .Add(new FireCooldownSystem())
                .Add(new DeathSystem())
                .Add(new DespawnSystem())
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                .Add(new IncomeSystem())

                .Add(new UnitSelectTargetSystem())
                .Add(new UnitMoveSystem())
                .Add(new UnitRotateSystem())
                .Add(new RangerUnitFireSystem(_projectilePrefab))
                .Add(new MeleeUnitFireSystem())
                
                .Add(new ArcherMoveDirectionSetSystem())
                .Add(new ArcherRotateDirectionSetSystem())
                .Add(new ArcherFireSystem())
                
                .Add(new SwordmanMoveDirectionSetSystem())
                .Add(new SwordmanRotateDirectionSetSystem())
                .Add(new SwordmanFireSystem())

                .Add(new ProjectileIniitalizer())
                .Add(new ProjectileCollisionSystem())

                //Rendering:
                .Add(new TransformViewSystem())
                .Add(new TeamViewSystem(_teamViewConfig))
                .Add(new MoveAnimSystem())
                .Add(new TakeDamageAnimSystem())
                .Add(new FireAnimSystem())

                //Clear:
                .ClearEvents<TakeDamageEvent>()
                .ClearEvents<FireEvent>()

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsConsts.EventWorld));
#endif
            return systems;
        }
    }
}