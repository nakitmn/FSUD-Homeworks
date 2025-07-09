using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveTowardsBehaviour : IFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            IReactiveVariable<Vector3> direction = entity.GetMoveDirection();
            MoveUseCase.MoveTowards(entity, direction.Value, deltaTime);
        }
    }
}