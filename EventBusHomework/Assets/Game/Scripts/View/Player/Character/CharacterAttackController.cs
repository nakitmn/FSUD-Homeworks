using Atomic.Entities;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterAttackController : IInit<IViewContext>, IUpdate<IViewContext>
    {
        private GameContext _gameContext;
        private GameBoard _gameBoard;

        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
            _gameBoard = _gameContext.GetGameBoard();
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsAttack(context) == false)
            {
                return;
            }

            var selectedEntity = context.GetSelectedCharacter().Value;

            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context.GetCamera(), Input.mousePosition, out EntityView target))
            {
                ViewCommandsUseCase.ExecuteWithVisual(
                        _gameContext,
                        context,
                        new CharacterAttackCommand(selectedEntity,
                            _gameBoard.GetBoardPosition((IGameEntity) target.Entity))
                    );
            }
        }
    }
}