using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "Swordman",
        menuName = "SampleGame/Entities/New Swordman"
    )]
    public sealed class SwordmanPrototype : EcsPrototype
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

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<SwordmanTag>().Add(entity);

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
            world.GetPool<MoveDirection>().Add(entity);

            //Rotate
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateDirection>().Add(entity);
            world.GetPool<RotationSpeed>().Add(entity).value = _rotationSpeed;
            
            //Fire:
            world.GetPool<FireCooldown>().Add(entity) = new FireCooldown
            {
                current = 0,
                duration = _fireCooldown
            };
        }
    }
}