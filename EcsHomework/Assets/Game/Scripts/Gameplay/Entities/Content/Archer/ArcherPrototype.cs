using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "Archer",
        menuName = "SampleGame/Entities/New Archer"
    )]
    public sealed class ArcherPrototype : EcsPrototype
    {
        [SerializeField]
        private float _moveSpeed = 3;

        [SerializeField]
        private float _rotationSpeed = 0.2f;

        [SerializeField]
        private int _health = 10;

        [SerializeField]
        private float _fireCooldown;

        [SerializeField]
        private float _attackDistance;
        
        [SerializeField]
        private int _ammo = 5;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<ArcherTag>().Add(entity);
            world.GetPool<RangerCombatTag>().Add(entity);

            //Unit
            world.GetPool<UnitTag>().Add(entity);
            world.GetPool<UnitMoveDirection>().Add(entity);
            world.GetPool<UnitRotateDirection>().Add(entity);
            world.GetPool<UnitFireRequired>().Add(entity);
            world.GetPool<UnitAttackDistance>().Add(entity).value = _attackDistance;
            
             world.GetPool<DeathTag>().Add(entity);
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };
            
            //Move
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity).value = new float3(0, 0, 1);

            //Rotate
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0, 0, -1);
            world.GetPool<RotationSpeed>().Add(entity).value = _rotationSpeed;
            
            //Fire:
            world.GetPool<Ammo>().Add(entity) = new Ammo
            {
                current = _ammo,
                max = _ammo
            };
            world.GetPool<FireOffset>().Add(entity).value = new float3(0, 1, 1);
            world.GetPool<FireCooldown>().Add(entity) = new FireCooldown
            {
                current = 0,
                duration = _fireCooldown
            };
        }
    }
}