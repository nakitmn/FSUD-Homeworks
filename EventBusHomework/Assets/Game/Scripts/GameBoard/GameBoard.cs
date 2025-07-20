using Atomic.Entities;

namespace SampleGame
{
    public sealed class GameBoard
    {
        private readonly IGameEntity[,] _board;

        public int Width => _board.GetLength(0);
        public int Height => _board.GetLength(1);

        public GameBoard(int width, int height)
        {
            _board = new IGameEntity[width, height];
        }

        public void Set(IGameEntity entity, int x, int y)
        {
            _board[x, y] = entity;
        }

        public IGameEntity Get(int x, int y)
        {
            return _board[x, y];
        }

        public bool IsFree(int x, int y)
        {
            return _board[x, y] == null;
        }

        public void Move(IGameEntity entity, int x, int y)
        {
            if (IsFree(x, y) == false)
            {
                return;
            }

            if (TryGetPosition(entity, out var entityX, out var entityY))
            {
                _board[entityX, entityY] = null;
            }

            _board[x, y] = entity;
        }

        public bool TryGetPosition(IGameEntity entity, out int x, out int y)
        {
            for (x = 0; x < _board.GetLength(0); x++)
            for (y = 0; y < _board.GetLength(1); y++)
            {
                if (_board[x, y] == entity)
                {
                    return true;
                }
            }

            x = y = -1;
            return false;
        }
    }
}