using Atomic.Entities;
using Atomic.Events;
using Game.Core;

namespace Game.View
{
    public sealed class GameBoardPresenter : IInit<IViewContext>, IEnable, IDisable
    {
        private GameContext _gameContext;
        private IEventBus _eventBus;
        private GameBoardView _gameBoardView;
        
        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
            _eventBus = _gameContext.GetEventBus();
            _gameBoardView = context.GetGameBoardView();
            var gameBoard = _gameContext.GetGameBoard();
            
            _gameBoardView.Create(gameBoard.Width, gameBoard.Height);
        }

        public void Enable(in IEntity entity)
        {
            _eventBus.SubscribeStartPlayerTurn(OnTurnStarted);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartPlayerTurn(OnTurnStarted);
        }

        private void OnTurnStarted()
        {
            _gameBoardView.ClearMaterials();

            if (WaveUseCase.TryGetCurrentWave(_gameContext, out var wave))
            {
                _gameBoardView.HighlightCells(wave.points);
            }
        }
    }
}