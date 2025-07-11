using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class SpawnBulletUseCase
    {
        public static IGameEntity SpawnBullet(
            in SceneEntity prefab,
            in IGameContext context,
            in Vector3 position,
            in Quaternion rotation,
            in IGameEntity owner
        )
        {
            IGameEntity bullet = (IGameEntity) context.GetEntityPool().Rent(prefab);
            bullet.GetOwner().Value = owner;
            
            Transform bulletTransform = bullet.GetTransform();
            bulletTransform.SetPositionAndRotation(position, rotation);

            bullet.GetLifetime().Reset();
            bullet.GetMoveDirection().Value = bulletTransform.forward;
            
            return bullet;
        }

        public static void UnspawnBullet(in IGameContext context, in IEntity bullet)
        {
            context.GetEntityPool().Return(bullet);
        }
    }
}