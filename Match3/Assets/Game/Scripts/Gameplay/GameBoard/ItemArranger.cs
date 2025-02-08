using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ItemArranger
    {
        private readonly GameBoard _gameBoard;

        public ItemArranger(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public Dictionary<Vector2Int, Vector2Int> Arrange()
        {
            var result = new Dictionary<Vector2Int, Vector2Int>();
            
            for (var col = 0; col < _gameBoard.Width; col++)
            {
                var lastPosition = new Vector2Int(_gameBoard.Height - 1, col);
                var fallAmount = _gameBoard.GetItem(lastPosition) == ItemType.None ? 1 : 0;

                for (var row = _gameBoard.Height - 2; row >= 0; row--)
                {
                    var position = new Vector2Int(row, col);
                    var item = _gameBoard.GetItem(position);

                    if (item == ItemType.None)
                    {
                        fallAmount++;
                        continue;
                    }

                    _gameBoard.RemoveItem(position, out _);
                    var fallPosition = new Vector2Int(row + fallAmount, col);
                    _gameBoard.SetItem(item, fallPosition);
                    result[position] = fallPosition;
                }
            }

            return result;
        }
    }
}