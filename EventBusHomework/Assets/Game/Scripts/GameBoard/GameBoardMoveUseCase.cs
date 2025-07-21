using UnityEngine;

namespace SampleGame
{
    public static class GameBoardMoveUseCase
    {
        public static bool Move(in IGameContext gameContext, in IGameEntity entity, in int x, in int y)
        {
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.TryGetPosition(entity, out var entityX, out var entityY) == false)
            {
                Debug.Log($"Can't find position for {entity.GetGameObject().name}");
                return false;
            }
            
            var moveRange = entity.GetMoveRange().Value;
            var targetBoardPosition = new Vector2Int(x, y);
            var entityBoardPosition = new Vector2Int(entityX, entityY);
            var direction = targetBoardPosition - entityBoardPosition;
            var clampedDirection = new Vector2Int()
            {
                x = Mathf.Clamp(direction.x, -moveRange, moveRange),
                y = Mathf.Clamp(direction.y, -moveRange, moveRange)
            };
            targetBoardPosition = entityBoardPosition + clampedDirection;
            return gameBoard.Move(entity, targetBoardPosition.x, targetBoardPosition.y);
        }

        public static Vector3 GetWorldPosition(in IGameContext gameContext, in IGameEntity entity)
        {
            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(entity, out var entityX, out var entityY);
            return GetWorldPosition(gameContext, entityX, entityY);
        }
        
        public static Vector3 GetWorldPosition(in IGameContext gameContext, in int x, in int y)
        {
            var gameBoardView = gameContext.GetGameBoardView();
            return gameBoardView.ToWorldPosition(x, y);
        }
        
        public static void GetDistance(in int originX, in int originY, in int targetX, in int targetY, out int distanceX, out int distanceY)
        {
            distanceX = Mathf.Abs(originX) - Mathf.Abs(targetX);
            distanceY = Mathf.Abs(originY) - Mathf.Abs(targetY);
        }
        
        public static bool IsPositionInRange(in int originX, in int originY, in int targetX, in int targetY, in int range)
        {
            GetDistance(originX, originY, targetX, targetY, out var distanceX, out var distanceY);
            return Mathf.Abs(distanceX) <= range && Mathf.Abs(distanceY) <= range;
        }
    }
}