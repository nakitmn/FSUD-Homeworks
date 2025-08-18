using System.Collections.Generic;

namespace SampleGame
{
    public static class GameBoardPositionsUseCase
    {
        public static IEnumerable<GameBoardPosition> GetMovePositions(IGameContext gameContext, IGameEntity entity)
        {
            var gameBoard = gameContext.GetGameBoard();
            
            if (gameBoard.TryGetPosition(entity,out var entityPosition) == false)
            {
                yield break;
            }

            var moveRange = entity.GetMoveRange().Value;

            for (var x = 0; x < gameBoard.Width; x++)
            for (var y = 0; y < gameBoard.Height; y++)
            {
                var position = new GameBoardPosition(x, y);
                if (position == entityPosition)
                {
                    continue;
                }
                
                if (GameBoardPosition.IsPositionInRange(entityPosition, position, moveRange))
                {
                    yield return position;
                }
            }
        }
    }
}