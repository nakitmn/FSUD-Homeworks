using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SpawnProjectileUseCase
    {
        public static IGameEntity Spawn(
            in GameEntity prefab,
            in IGameContext context,
            in Vector3 position,
            in Quaternion rotation,
            in IGameEntity owner
        )
        {
            var projectile = (IGameEntity) context.GetEntityPool().Rent(prefab);
            projectile.GetOwner().Value = owner;
            
            var bulletTransform = projectile.GetTransform();
            bulletTransform.SetPositionAndRotation(position, rotation);

            projectile.GetLifetime().Reset();
            projectile.GetMoveDirection().Value = bulletTransform.forward;
            projectile.GetFireAction().Invoke();
            
            return projectile;
        }

        public static void Unspawn(in IGameContext context, in IEntity bullet)
        {
            context.GetEntityPool().Return(bullet);
        }
    }
}