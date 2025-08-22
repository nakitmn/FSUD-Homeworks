using Atomic.Elements;
using Atomic.Entities;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public sealed class CharacterMoveController : IInit<IViewContext>, IUpdate<IViewContext>
    {
        private GameContext _gameContext;
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private Camera _camera;
        private GameBoardView _gameBoardView;

        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
            
            _selectedCharacter = context.GetSelectedCharacter();
            _gameBoardView = context.GetGameBoardView();
            _camera = context.GetCamera();
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsMove(context) == false)
            {
                return;
            }

            if (_selectedCharacter.Value != null &&
                RaycastUseCase.RaycastTarget(_camera, Input.mousePosition, out GameBoardCellView cellView))
            {
                var boardPosition = _gameBoardView.GetBoardPosition(cellView);
                var command = new CharacterMoveCommand(_selectedCharacter.Value, boardPosition);
                ViewCommandsUseCase.ExecuteWithAnimation(_gameContext, context, command);
                _selectedCharacter.Value = null;
            }
        }
    }
}