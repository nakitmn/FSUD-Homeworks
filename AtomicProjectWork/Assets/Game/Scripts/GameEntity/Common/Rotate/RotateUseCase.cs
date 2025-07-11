using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class RotateUseCase
    {
        public static void RotateTowardsPosition(in IGameEntity entity, in Vector3 position)
        {
            var transform = entity.GetTransform();
            var direction = VectorUseCase.GetDirectionXZ(transform.position, position);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public static void RotateTowardsPosition(in IGameEntity entity, in Vector3 position, in float deltaTime)
        {
            var direction = VectorUseCase.GetDirectionXZ(entity.GetTransform().position, position);
            RotateTowards(entity, direction, deltaTime);
        }

        public static void RotateTowards(in IGameEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (direction == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            RotateTowards(entity, targetRotation, deltaTime);
        }

        public static void RotateTowards(in IGameEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            float speed = entity.GetAngularSpeed().Value * deltaTime;
            Transform transform = entity.GetTransform();
            transform.rotation = RotateTowards(transform.rotation, targetRotation, speed);
        }

        public static Quaternion RotateTowards(in Quaternion currentRotation, in Quaternion targetRotation,
            in float speed)
        {
            return Quaternion.Lerp(currentRotation, targetRotation, speed);
        }
    }
}