using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class TakeDamageUseCase
    {
        public static bool TakeDamage(in IEntity target, in int damage, IEntity source)
        {
            if (!target.HasDamageableTag())
                return false;

            if (target.Id == source.Id)
            {
                return false;
            }

            IReactiveVariable<int> health = target.GetHealth();

            int current = health.Value;
            if (current <= 0)
                return false;

            health.Value = Math.Max(0, current - damage);
            target.GetDamagedEvent().Invoke();
            return true;
        }

        public static void TakePointDamage(Vector3 position, float radius, int damage, IEntity owner)
        {
            var colliders = RaycastUseCase.ScanTargets(position, radius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IEntity entity))
                {
                    TakeDamage(entity, damage, owner);
                }
            }
        }

        public static int GetExtraDamage(int damage, IEntity owner)
        {
            if (owner != null && owner.TryGetExtraDamage(out IExpression<int> extraDamage))
                return damage + extraDamage.Value;

            return damage;
        }
    }
}