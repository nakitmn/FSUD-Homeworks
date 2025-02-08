using System;
using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameBoard
    {
        public int Width => _items.GetLength(0);
        public int Height => _items.GetLength(1);

        private readonly ItemType[,] _items;

        public GameBoard(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Matrix size");
            }

            _items = new ItemType[width, height];
        }

        public GameBoard(int width, int height, params KeyValuePair<ItemType, Vector2Int>[] items) : this(width, height)
        {
            if (items == null)
            {
                throw new NullReferenceException(nameof(items));
            }

            foreach (var (item, position) in items)
            {
                _items[position.y, position.x] = item;
            }
        }

        public GameBoard(ItemType[,] matrix)
        {
            if (matrix == null)
            {
                throw new NullReferenceException(nameof(matrix));
            }

            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
            {
                throw new ArgumentException(nameof(matrix));
            }

            _items = new ItemType[matrix.GetLength(0), matrix.GetLength(1)];

            for (var col = 0; col < Width; col++)
            {
                for (var row = 0; row < Height; row++)
                {
                    _items[col, row] = matrix[col, row];
                }
            }
        }

        public void SetItem(ItemType item, Vector2Int position)
        {
            if (IsPositionInBounds(position) == false)
            {
                throw new ArgumentException(nameof(position));
            }

            _items[position.y, position.x] = item;
        }

        public ItemType GetItem(Vector2Int position)
        {
            if (IsPositionInBounds(position) == false)
            {
                throw new ArgumentException(nameof(position));
            }

            return _items[position.y, position.x];
        }

        public bool RemoveItem(Vector2Int position, out ItemType item)
        {
            if (IsPositionInBounds(position) == false)
            {
                throw new ArgumentException(nameof(position));
            }

            item = GetItem(position);

            if (item == ItemType.None)
            {
                return false;
            }

            _items[position.y, position.x] = ItemType.None;
            return true;
        }

        public bool IsPositionInBounds(Vector2Int position)
        {
            return position.x >= 0 && position.x < Height && position.y >= 0 && position.y < Width;
        }

        public bool AreSame(ItemType[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.GetLength(0) != Width || matrix.GetLength(1) != Height)
            {
                return false;
            }

            for (var col = 0; col < Width; col++)
            {
                for (var row = 0; row < Height; row++)
                {
                    if (_items[col, row] != matrix[col, row])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}