using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class RotateTowardsBehaviour : IFixedUpdate<IGameEntity>
    {
        public void OnFixedUpdate(IGameEntity entity, in float deltaTime)
        {
            Vector3 direction = entity.GetAngularDirection().Value;
            RotateUseCase.RotateTowards(entity, direction, deltaTime);
        }
    }
}