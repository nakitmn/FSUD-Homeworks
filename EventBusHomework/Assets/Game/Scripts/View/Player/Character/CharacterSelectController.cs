using Atomic.Elements;
using Atomic.Entities;
using Atomic.Events;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public sealed class CharacterSelectController : IInit<IViewContext>, IEnable, IDisable, IUpdate<IViewContext>
    {
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private IEventBus _eventBus;

        public void Init(IViewContext context)
        {
            var gameContext = GameContext.Instance;
            _eventBus = gameContext.GetEventBus();
            _selectedCharacter = context.GetSelectedCharacter();
        }

        public void Enable(in IEntity entity)
        {
            _eventBus.SubscribeStartPlayerTurn(ClearSelection);
            _eventBus.SubscribeEndPlayerTurn(ClearSelection);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartPlayerTurn(ClearSelection);
            _eventBus.UnsubscribeEndPlayerTurn(ClearSelection);
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsSelect(context) &&
                RaycastUseCase.RaycastTarget(context.GetCamera(), Input.mousePosition, out EntityView target))
            {
                var gameEntity = (IGameEntity) target.Entity;
                if (gameEntity.HasCharacterTag())
                {
                    _selectedCharacter.Value = gameEntity;
                }
            }
        }

        private void ClearSelection()
        {
            _selectedCharacter.Value = null;
        }
    }
}