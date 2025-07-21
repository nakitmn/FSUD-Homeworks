using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterMoveController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsMove(context) == false)
            {
                return;
            }
            
            var selectedEntity = context.GetSelectedCharacter().Value;
                
            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context, Input.mousePosition, out IGameEntity target) &&
                target.HasCellTag())
            {
                var moveCommand =
                    new CharacterMoveCommand(selectedEntity, target.GetBoardPosition().Value);
                moveCommand.Execute(context);
            }
        }
    }
}