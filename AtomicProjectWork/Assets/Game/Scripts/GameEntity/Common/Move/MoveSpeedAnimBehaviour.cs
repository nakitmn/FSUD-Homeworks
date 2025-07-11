using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveSpeedAnimBehaviour : IInit<IGameEntity>, IUpdate
    {
        private readonly int _currentSpeedHash;
        private Animator _animator;
        private IValue<float> _normalizedCurrentSpeed;

        public MoveSpeedAnimBehaviour(string key)
        {
            _currentSpeedHash = Animator.StringToHash(key);
        }

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            _normalizedCurrentSpeed = entity.GetNormalizedCurrentSpeed();   
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _animator.SetFloat(_currentSpeedHash, _normalizedCurrentSpeed.Value);
        }
    }
}