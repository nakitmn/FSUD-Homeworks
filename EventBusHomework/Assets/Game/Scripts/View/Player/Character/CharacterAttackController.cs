using Atomic.Elements;
using Atomic.Entities;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public sealed class CharacterAttackController : IInit<IViewContext>, IUpdate<IViewContext>
    {
        private GameContext _gameContext;
        private GameBoard _gameBoard;
        private Camera _camera;
        private IReactiveVariable<IGameEntity> _selectedCharacter;

        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
            _gameBoard = _gameContext.GetGameBoard();
            
            _camera = context.GetCamera();
            _selectedCharacter = context.GetSelectedCharacter();
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsAttack(context) == false)
            {
                return;
            }

            if (_selectedCharacter.Value != null &&
                RaycastUseCase.RaycastTarget(_camera, Input.mousePosition, out EntityView target))
            {
                var targetBoardPosition = _gameBoard.GetBoardPosition((IGameEntity) target.Entity);
                var command = new CharacterAttackCommand(_selectedCharacter.Value, targetBoardPosition);
                ViewCommandsUseCase.ExecuteWithAnimation(_gameContext, context, command);
                _selectedCharacter.Value = null;
            }
        }
    }
}