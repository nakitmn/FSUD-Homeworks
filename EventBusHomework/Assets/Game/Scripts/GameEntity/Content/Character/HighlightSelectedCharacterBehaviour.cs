using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public sealed class HighlightSelectedCharacterBehaviour : IInit<IGameEntity>, IEnable, IDisable
    {
        private IGameEntity _entity;
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private IReactiveVariable<Tween> _selectedAnimation;
        private Transform _transform;

        public void Init(IGameEntity entity)
        {
            var gameContext = GameContext.Instance;
            _selectedCharacter = gameContext.GetSelectedCharacter();
            
            _entity = entity;
            _selectedAnimation = entity.GetSelectedAnimation();
            _transform = entity.GetVisualTransform();
        }

        public void Enable(in IEntity entity)
        {
            _selectedCharacter.Observe(OnSelectedCharacterChanged);
        }

        public void Disable(in IEntity entity)
        {
            _selectedCharacter.Unsubscribe(OnSelectedCharacterChanged);
        }

        private void OnSelectedCharacterChanged(IGameEntity entity)
        {
            if (_entity.Equals(entity))
            {
                if (_selectedAnimation.Value.IsActive() == false)
                {
                    _selectedAnimation.Value = _transform.DOScale(Vector3.one * 1.1f, 1f)
                        .ChangeStartValue(Vector3.one)
                        .SetLoops(-1, LoopType.Yoyo);
                }
            }
            else
            {
                if (_selectedAnimation.Value.IsActive())
                {
                    _selectedAnimation.Value.Kill();
                    _transform.localScale = Vector3.one;
                }
            }
        }
    }
}