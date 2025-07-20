using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterMoveController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var selectedEntity = context.GetSelectedCharacter().Value;
                if (selectedEntity == null)
                {
                    return;
                }
                
                if (RaycastUseCase.RaycastTarget(context,Input.mousePosition, out IGameEntity target))
                {
                    if (target.HasCellTag())
                    {
                        var moveCommand = new MoveCommand(selectedEntity,target.GetX().Value, target.GetY().Value);
                        moveCommand.Execute(context);
                    }
                }
            }
        }
    }
}