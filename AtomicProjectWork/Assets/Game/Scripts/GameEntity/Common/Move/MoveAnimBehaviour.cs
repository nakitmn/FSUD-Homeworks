using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveAnimBehaviour : IInit<IGameEntity>, IUpdate<IGameEntity>
    {
        private readonly int _isMovingHash;
        private Animator _animator;

        public MoveAnimBehaviour(string isMovingHash)
        {
            _isMovingHash = Animator.StringToHash(isMovingHash);
        }

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(IGameEntity entity, in float deltaTime)
        {
            _animator.SetBool(_isMovingHash, MoveUseCase.IsMoving(entity));
        }
    }
}