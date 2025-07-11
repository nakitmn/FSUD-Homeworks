using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveTowardsBehaviour : IFixedUpdate<IGameEntity>
    {
        public void OnFixedUpdate(IGameEntity entity, in float deltaTime)
        {
            IReactiveVariable<Vector3> direction = entity.GetMoveDirection();
            MoveUseCase.MoveTowards(entity, direction.Value, deltaTime);
        }
    }
}