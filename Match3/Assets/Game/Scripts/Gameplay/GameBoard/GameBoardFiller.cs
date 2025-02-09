using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameBoardFiller
    {
        private static readonly ItemType[] _availableItems =
        {
            ItemType.Blue,
            ItemType.Green,
            ItemType.Orange,
            ItemType.Purple,
            ItemType.Red,
            ItemType.Yellow
        };

        private readonly GameBoard _gameBoard;

        public GameBoardFiller(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public Dictionary<Vector2Int, ItemType> Fill()
        {
            var result = new Dictionary<Vector2Int, ItemType>();
            var fillPositions = _gameBoard.GetPositionsOfItems(ItemType.None);

            foreach (var position in fillPositions)
            {
                var item = GenerateItem();
                _gameBoard.SetItem(item, position);
                result[position] = item;
            }

            return result;
        }

        private ItemType GenerateItem()
        {
            return _availableItems[Random.Range(0, _availableItems.Length)];
        }
    }
}