using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class RotateToTargetPointBehaviour : IInit<Ability>, IUpdate
    {
        private readonly IGameEntity _entity;
        
        private IReactiveVariable<Vector3> _targetPoint;
        private IValue<bool> _isRunning;

        public RotateToTargetPointBehaviour(IGameEntity entity)
        {
            _entity = entity;
        }

        public void Init(Ability ability)
        {
            _targetPoint = ability.GetTargetPoint();
            _isRunning = ability.GetIsRunning();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (_isRunning.Value)
            {
                RotateUseCase.RotateTowardsPosition(_entity, _targetPoint.Value, deltaTime);
            }
        }
    }
}