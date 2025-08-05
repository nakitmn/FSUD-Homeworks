using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class GameBoard
    {
        [ShowInInspector] private readonly IGameEntity[,] _board;

        public int Width => _board.GetLength(0);
        public int Height => _board.GetLength(1);

        public IGameEntity this[GameBoardPosition position]
        {
            get => _board[position.x, position.y];
            set => _board[position.x, position.y] = value;
        }        
        
        public GameBoard(int width, int height)
        {
            _board = new IGameEntity[width, height];
        }

        public bool IsFree(GameBoardPosition position)
        {
            return this[position] == null;
        }

        public bool Set(IGameEntity entity, GameBoardPosition position)
        {
            if (IsFree(position) == false)
            {
                return false;
            }

            if (TryGetPosition(entity, out var entityPosition))
            {
                this[entityPosition] = null;
            }

            this[position] = entity;
            return true;
        }
        
        public bool Move(IGameEntity entity, GameBoardPosition targetPosition)
        {
            if (TryGetPosition(entity, out var entityPosition) == false)
            {
                Debug.Log($"Can't find position for {entity.Name}");
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
            return Set(entity, clampedTargetPosition);
        }

        public bool TryGetPosition(IGameEntity entity, out GameBoardPosition position)
        {
            for (var x = 0; x < _board.GetLength(0); x++)
            for (var y = 0; y < _board.GetLength(1); y++)
            {
                var boardEntity = _board[x, y];
                if (boardEntity == null)
                {
                    continue;
                }
                
                if (boardEntity.Equals(entity))
                {
                    position = new()
                    {
                        x = x,
                        y = y
                    };
                    return true;
                }
            }
            
            position = GameBoardPosition.Invalid;
            return false;
        }
        
        public GameBoardPosition GetBoardPosition(IGameEntity entity)
        {
            TryGetPosition(entity, out var entityPosition);
            return entityPosition;
        }

        public bool IsInBounds(GameBoardPosition position)
        {
            return position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;
        }
    }
}