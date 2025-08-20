using Atomic.Elements;
using Atomic.Entities;
using Game.Core;
using SampleGame;

namespace Game.View
{
    public sealed class SelectedCharacterCellsPresenter : IInit<IViewContext>, IEnable, IDisable
    {
        private IViewContext _viewContext;
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private GameBoardView _gameBoardView;
        private GameContext _gameContext;

        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
            _viewContext = context;
            _gameBoardView = _viewContext.GetGameBoardView();
            _selectedCharacter = _viewContext.GetSelectedCharacter();
        }

        public void Enable(in IEntity entity)
        {
            _selectedCharacter.Subscribe(OnCharacterChanged);
        }

        public void Disable(in IEntity entity)
        {
            _selectedCharacter.Unsubscribe(OnCharacterChanged);
        }

        private void OnCharacterChanged(IGameEntity entity)
        {
            _gameBoardView.ResetMoveEnabled();
            
            if (entity == null)
            {
                return;
            }
            
            var positions = GameBoardPositionsUseCase.GetMovePositions(_gameContext, entity);
            _gameBoardView.SetMoveEnabled(positions);
        }
    }
}