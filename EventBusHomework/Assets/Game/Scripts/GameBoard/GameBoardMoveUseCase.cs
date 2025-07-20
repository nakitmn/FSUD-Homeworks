using UnityEngine;

namespace SampleGame
{
    public static class GameBoardMoveUseCase
    {
        public static bool Move(in IGameContext gameContext, in IGameEntity entity, in int x, in int y)
        {
            var gameBoard = gameContext.GetGameBoard();

            var moveRange = entity.GetMoveRange().Value;
            var targetBoardPosition = new Vector2Int(x, y);

            if (gameBoard.TryGetPosition(entity, out var entityX, out var entityY))
            {
                var entityBoardPosition = new Vector2Int(entityX, entityY);
                var direction = targetBoardPosition - entityBoardPosition;
                var clampedDirection = new Vector2Int()
                {
                    x = Mathf.Clamp(direction.x, -moveRange, moveRange),
                    y = Mathf.Clamp(direction.y, -moveRange, moveRange)
                };
                targetBoardPosition = entityBoardPosition + clampedDirection;
            }

            return GameBoardSetUseCase.Set(gameContext, entity, targetBoardPosition.x, targetBoardPosition.y);
        }
    }
}