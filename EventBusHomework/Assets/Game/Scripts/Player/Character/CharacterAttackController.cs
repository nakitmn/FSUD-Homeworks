using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterAttackController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var selectedEntity = context.GetSelectedCharacter().Value;
                if (selectedEntity == null)
                {
                    return;
                }

                if (RaycastUseCase.RaycastTarget(context, Input.mousePosition, out IGameEntity target))
                {
                    if (target.HasCellTag())
                    {
                        var attackCommand =
                            new CharacterAttackCommand(selectedEntity, target.GetX().Value, target.GetY().Value);
                        attackCommand.Execute(context);
                    }

                    if (target.HasCharacterTag())
                    {
                        var gameBoard = context.GetGameBoard();
                        if (gameBoard.TryGetPosition(target, out var x, out var y))
                        {
                            var attackCommand = new CharacterAttackCommand(selectedEntity, x, y);
                            attackCommand.Execute(context);
                        }
                    }
                }
            }
        }
    }
}