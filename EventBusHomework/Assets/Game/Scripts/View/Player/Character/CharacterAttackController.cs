using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterAttackController : IInit,IUpdate<IGameContext>
    {
        private Camera _camera;

        public void Init(in IEntity entity)
        {
            _camera = Camera.main;
        }

        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsAttack(context) == false)
            {
                return;
            }

            var selectedEntity = context.GetSelectedCharacter().Value;

            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(_camera, Input.mousePosition, out IGameEntity target))
            {
                //TODO: Attack Command 
                
                if (target.HasCellTag())
                {
                    /*var attackCommand =
                        new CharacterAttackCommand(selectedEntity, target.GetBoardPosition().Value);
                    attackCommand.Execute(context);*/
                }

                if (target.HasCharacterTag())
                {
                    /*var gameBoard = context.GetGameBoard();
                    if (gameBoard.TryGetPosition(target, out var position))
                    {
                        var attackCommand = new CharacterAttackCommand(selectedEntity, position);
                        attackCommand.Execute(context);
                    }*/
                }
            }
        }
    }
}