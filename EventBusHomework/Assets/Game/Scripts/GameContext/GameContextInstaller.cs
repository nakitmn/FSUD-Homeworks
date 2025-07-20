using Atomic.Entities;
using Atomic.Events;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private SceneEventBus _eventBus;
        [SerializeField] private Vector2Int _gameBoardSize;
        [SerializeField] private GameBoardView _gameBoardView;
        
        protected override void Install(IGameContext entity)
        {
            entity.AddEventBus(_eventBus);
            entity.AddGameBoard(new GameBoard(_gameBoardSize.x,_gameBoardSize.y));
            entity.AddGameBoardView(_gameBoardView);
        }
    }
}