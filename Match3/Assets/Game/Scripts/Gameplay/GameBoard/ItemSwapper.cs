using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ItemSwapper
    {
        private readonly GameBoard _gameBoard;

        private static readonly Vector2Int[] _swapDirections =
        {
            Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
        };

        public ItemSwapper(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public bool CanSwap(Vector2Int first, Vector2Int second)
        {
            return _gameBoard.IsPositionInBounds(first)
                   && _gameBoard.IsPositionInBounds(second)
                   && CheckDirections(first, second);
        }

        private bool CheckDirections(Vector2Int first, Vector2Int second)
        {
            foreach (var swapDirection in _swapDirections)
            {
                var availablePosition = first + swapDirection;

                if (availablePosition == second)
                {
                    return true;
                }
            }

            return false;
        }

        public bool SwapItems(Vector2Int first, Vector2Int second)
        {
            if (CanSwap(first, second) == false)
            {
                return false;
            }

            var firstItem = _gameBoard.GetItem(first);
            var secondItem = _gameBoard.GetItem(second);
            
            _gameBoard.SetItem(secondItem, first);
            _gameBoard.SetItem(firstItem, second);
            
            return true;
        }
    }
}