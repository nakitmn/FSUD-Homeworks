using System;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public struct GameBoardPosition
    {
        public int x;
        public int y;

        public GameBoardPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static GameBoardPosition Invalid => new() { x = -1, y = -1 };
        
        public static GameBoardPosition operator +(GameBoardPosition position, Vector2Int vector)
        {
            return new GameBoardPosition(position.x + vector.x, position.y + vector.y);
        }
        
        public static GameBoardPosition operator +(GameBoardPosition a, GameBoardPosition b)
        {
            return new GameBoardPosition(a.x + b.x, a.y + b.y);
        }
        
        public static GameBoardPosition operator -(GameBoardPosition a, GameBoardPosition b)
        {
            return new GameBoardPosition(a.x - b.x, a.y - b.y);
        }
        
        public static bool operator ==(GameBoardPosition a, GameBoardPosition b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(GameBoardPosition a, GameBoardPosition b)
        {
            return !(a == b);
        }

        public static Vector2Int GetDirection(GameBoardPosition from, GameBoardPosition to)
        {
            return new Vector2Int()
            {
                x = to.x - from.x,
                y = to.y - from.y
            };
        }
        
        public static void GetDistance(GameBoardPosition originPosition, GameBoardPosition targetPosition,
            out int distanceX, out int distanceY)
        {
            distanceX = Mathf.Abs(originPosition.x) - Mathf.Abs(targetPosition.x);
            distanceY = Mathf.Abs(originPosition.y) - Mathf.Abs(targetPosition.y);
        }
        
        public static bool IsPositionInRange(GameBoardPosition originPosition, GameBoardPosition targetPosition, int range)
        {
            GetDistance(originPosition, targetPosition, out var distanceX, out var distanceY);
            return Mathf.Abs(distanceX) <= range && Mathf.Abs(distanceY) <= range;
        }
        
        public static GameBoardPosition FromVector2Int(Vector2Int vector)
        {
            return new(vector.x, vector.y);
        }

        public Vector2Int ToVector2Int()
        {
            return new Vector2Int(x, y);
        }

        public override string ToString()
        {
            return $"[{x};{y}]";
        }
    }
}