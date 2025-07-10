using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveSpeedAnimBehaviour : IInit, IUpdate
    {
        private readonly int _currentSpeedHash;
        private Animator _animator;

        public MoveSpeedAnimBehaviour(string key)
        {
            _currentSpeedHash = Animator.StringToHash(key);
        }

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _animator.SetFloat(_currentSpeedHash, entity.GetNormalizedCurrentSpeed().Value);
        }
    }
}