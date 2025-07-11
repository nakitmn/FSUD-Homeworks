using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class VectorUseCase
    {
        public static Vector3 GetDirectionXZ(in Vector3 originalPosition, in Vector3 targetPosition)
        {
            var direction = targetPosition - originalPosition;
            direction.y = 0f;
            return direction.normalized;
        }
        
        public static bool LessOrEqualsDistance(in IGameEntity entity, in Vector3 point, float distance) =>
            GetDistance(entity, point) <= distance;

        public static float GetDistance(in IGameEntity entity, Vector3 position)
        {
            Vector3 currentPosition = entity.GetTransform().position;
            Vector3 distance = position - currentPosition;
            return distance.magnitude;
        }

        public static Vector3 GetPositionInRadius(Vector3 position, float radius)
        {
            var randomPosition = Random.insideUnitSphere;
            randomPosition.y = 0f;
            randomPosition *= radius;
            return position + randomPosition;
        }
    }
}