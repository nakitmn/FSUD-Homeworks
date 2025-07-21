using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterMoveController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (Input.GetMouseButtonDown(0) == false)
            {
                return;
            }
            
            var selectedEntity = context.GetSelectedCharacter().Value;
                
            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context, Input.mousePosition, out IGameEntity target) &&
                target.HasCellTag())
            {
                var moveCommand =
                    new CharacterMoveCommand(selectedEntity, target.GetX().Value, target.GetY().Value);
                moveCommand.Execute(context);
            }
        }
    }
}