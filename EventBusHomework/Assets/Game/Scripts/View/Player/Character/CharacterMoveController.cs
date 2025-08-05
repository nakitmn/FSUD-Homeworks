using Atomic.Entities;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterMoveController : IInit, IUpdate<IViewContext>
    {
        private GameContext _gameContext;

        public void Init(in IEntity entity)
        {
            _gameContext = GameContext.Instance;
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsMove(context) == false)
            {
                return;
            }

            var selectedEntity = context.GetSelectedCharacter().Value;

            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context.GetCamera(), Input.mousePosition, out GameBoardCellView cellView))
            {
                ViewCommandsUseCase.ExecuteWithVisual(
                    _gameContext, 
                    context,   
                    new CharacterMoveCommand(selectedEntity, context.GetGameBoardPresenter().GetBoardPosition(cellView)));
            }
        }
    }
}