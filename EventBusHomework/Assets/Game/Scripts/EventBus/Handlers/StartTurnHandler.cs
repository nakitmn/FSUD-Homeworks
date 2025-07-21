using System.Collections.Generic;
using Atomic.Entities;
using Atomic.Events;
using Random = UnityEngine.Random;

namespace SampleGame
{
    public sealed class StartTurnHandler : IInit<IGameContext>, IEnable, IDisable
    {
        private IEventBus _eventBus;
        private IGameContext _context;

        public void Init(IGameContext context)
        {
            _context = context;
            _eventBus = context.GetEventBus();
        }

        public void Enable(in IEntity entity)
        {
            _eventBus.SubscribeStartTurn(OnTurnStart);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeStartTurn(OnTurnStart);
        }

        private void OnTurnStart()
        {
            CharacterTurnUseCase.ResetCharacters(_context);
            SelectSpawnCells(_context);
            _context.GetTurn().Value++;
        }

        private void SelectSpawnCells(IGameContext context)
        {
            var gameBoard = context.GetGameBoard();
            var freePositions = new List<GameBoardPosition>();
            
            for (var x = 0; x < gameBoard.Width; x++)
            for (var y = 0; y < gameBoard.Height; y++)
            {
                var position = new GameBoardPosition(x,y);
                if (gameBoard.IsFree(position))
                {
                    freePositions.Add(position);
                }
            }

            var spawnCount = context.GetSpawnCount().Value;
            var spawnPositions = new List<GameBoardPosition>(spawnCount);
            
            for (var i = 0; i < spawnCount; i++)
            {
                var index = Random.Range(0, freePositions.Count);
                spawnPositions.Add(freePositions[index]);
                freePositions.RemoveAt(index);
            }
            
            context.SetSpawnPoints(spawnPositions);
        }
    }
}