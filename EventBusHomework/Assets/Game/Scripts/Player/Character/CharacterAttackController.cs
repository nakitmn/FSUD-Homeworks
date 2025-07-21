using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterAttackController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (Input.GetMouseButtonDown(1) == false)
            {
                return;
            }

            var selectedEntity = context.GetSelectedCharacter().Value;

            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context, Input.mousePosition, out IGameEntity target))
            {
                if (target.HasCellTag())
                {
                    var attackCommand =
                        new CharacterAttackCommand(selectedEntity, target.GetBoardPosition().Value);
                    attackCommand.Execute(context);
                }

                if (target.HasCharacterTag())
                {
                    var gameBoard = context.GetGameBoard();
                    if (gameBoard.TryGetPosition(target, out var position))
                    {
                        var attackCommand = new CharacterAttackCommand(selectedEntity, position);
                        attackCommand.Execute(context);
                    }
                }
            }
        }
    }
}