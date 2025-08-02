using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterMoveController : IInit, IUpdate<IGameContext>
    {
        private Camera _camera;

        public void Init(in IEntity entity)
        {
            _camera = Camera.main;
        }
        
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsMove(context) == false)
            {
                return;
            }
            
            var selectedEntity = context.GetSelectedCharacter().Value;
                
            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(_camera, Input.mousePosition, out IGameEntity target) &&
                target.HasCellTag())
            {
                //TODO: Move Command 
                
                /*var moveCommand =
                    new CharacterMoveCommand(selectedEntity, target.GetBoardPosition().Value);
                moveCommand.Execute(context);*/
            }
        }
    }
}