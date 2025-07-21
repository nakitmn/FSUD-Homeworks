using UnityEngine;

namespace SampleGame
{
    public static class GameBoardMoveUseCase
    {
        public static bool Move(in IGameContext gameContext, in IGameEntity entity, in GameBoardPosition targetPosition)
        {
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.TryGetPosition(entity, out var entityPosition) == false)
            {
                Debug.Log($"Can't find position for {entity.GetGameObject().name}");
                return false;
            }
            
            var moveRange = entity.GetMoveRange().Value;
            var direction = GameBoardPosition.GetDirection(entityPosition, targetPosition);
            var clampedDirection = new Vector2Int()
            {
                x = Mathf.Clamp(direction.x, -moveRange, moveRange),
                y = Mathf.Clamp(direction.y, -moveRange, moveRange)
            };
            var clampedTargetPosition = entityPosition + clampedDirection;
            return gameBoard.Move(entity, clampedTargetPosition);
        }

        public static Vector3 GetWorldPosition(in IGameContext gameContext, in IGameEntity entity)
        {
            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(entity, out var entityPosition);
            return GetWorldPosition(gameContext, entityPosition);
        }
        
        public static Vector3 GetWorldPosition(in IGameContext gameContext, in GameBoardPosition position)
        {
            var gameBoardView = gameContext.GetGameBoardView();
            return gameBoardView.ToWorldPosition(position.x, position.y);
        }
        
        public static GameBoardPosition GetBoardPosition(in IGameContext gameContext, in IGameEntity entity)
        {
            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(entity, out var entityPosition);
            return entityPosition;
        }
        
        public static void GetDistance(in GameBoardPosition originPosition, in GameBoardPosition targetPosition, out int distanceX, out int distanceY)
        {
            distanceX = Mathf.Abs(originPosition.x) - Mathf.Abs(targetPosition.x);
            distanceY = Mathf.Abs(originPosition.y) - Mathf.Abs(targetPosition.y);
        }
        
        public static bool IsPositionInRange(in GameBoardPosition originPosition, in GameBoardPosition targetPosition, in int range)
        {
            GetDistance(originPosition, targetPosition, out var distanceX, out var distanceY);
            return Mathf.Abs(distanceX) <= range && Mathf.Abs(distanceY) <= range;
        }
    }
}