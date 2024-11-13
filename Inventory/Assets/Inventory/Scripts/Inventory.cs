using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable NotResolvedInText

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width => _cells.GetLength(0);
        public int Height => _cells.GetLength(1);
        public int Count => _cachedItems.Count;

        private readonly Item[,] _cells;
        private readonly Dictionary<Item, Vector2Int> _cachedItems;

        public Inventory(in int width, in int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid inventory size!");
            }

            _cells = new Item[width, height];
            _cachedItems = new Dictionary<Item, Vector2Int>();
        }

        public Inventory(
            in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Can't create inventory with null items!");
            }

            foreach (var (item, position) in items)
            {
                AddItem(item, position);
            }
        }

        public Inventory(
            in int width,
            in int height,
            params Item[] items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Can't create inventory with null items!");
            }

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Can't create inventory with null items!");
            }

            foreach (var (item, position) in items)
            {
                AddItem(item, position);
            }
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<Item> items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Can't create inventory with null items!");
            }

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            if (item == null)
            {
                return false;
            }

            if (IsValidSize(item.Size) == false)
            {
                throw new ArgumentException("Invalid item size!");
            }

            return Contains(item) == false
                   && IsAreaInBounds(position, item.Size)
                   && IsAreaFree(position, item.Size);
        }

        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            return CanAddItem(item, new Vector2Int(posX, posY));
        }

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (CanAddItem(item, position) == false)
            {
                return false;
            }

            foreach (var addPosition in GetPositionsAt(position, item.Size))
            {
                _cells[addPosition.x, addPosition.y] = item;
            }

            _cachedItems.Add(item, position);
            OnAdded?.Invoke(item, position);
            return true;
        }

        public bool AddItem(in Item item, in int posX, in int posY)
        {
            return AddItem(item, new Vector2Int(posX, posY));
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (item == null)
            {
                return false;
            }

            return FindFreePosition(item.Size, out var position)
                   && CanAddItem(item, position);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
        {
            return CanAddItem(item)
                   && FindFreePosition(item.Size, out var position)
                   && AddItem(item, position);
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            if (IsValidSize(size) == false)
            {
                throw new ArgumentOutOfRangeException("Invalid item size!");
            }

            if (IsSizeFitsInInventory(size) == false)
            {
                freePosition = default;
                return false;
            }

            for (var row = 0; row < Height; row++)
            for (var col = 0; col < Width; col++)
            {
                var checkingPosition = new Vector2Int(col, row);

                if (IsAreaInBounds(checkingPosition, size)
                    && IsAreaFree(checkingPosition, size))
                {
                    freePosition = checkingPosition;
                    return true;
                }
            }

            freePosition = default;
            return false;
        }

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            return item != null && _cachedItems.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position)
        {
            return IsFree(position) == false;
        }

        public bool IsOccupied(in int x, in int y)
        {
            return IsOccupied(new Vector2Int(x, y));
        }

        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position)
        {
            return _cells[position.x, position.y] == null;
        }

        public bool IsFree(in int x, in int y)
        {
            return IsFree(new Vector2Int(x, y));
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
        {
            if (item == null || Contains(item) == false)
            {
                return false;
            }

            _cachedItems.Remove(item, out var pivotPosition);

            foreach (var itemPosition in GetPositionsAt(pivotPosition, item.Size))
            {
                _cells[itemPosition.x, itemPosition.y] = null;
            }

            return true;
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            position = default;

            if (item == null || Contains(item) == false)
            {
                return false;
            }

            _cachedItems.Remove(item, out position);

            foreach (var itemPosition in GetPositionsAt(position, item.Size))
            {
                _cells[itemPosition.x, itemPosition.y] = null;
            }

            OnRemoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            if (IsPositionInBounds(position) == false)
            {
                throw new IndexOutOfRangeException();
            }

            var item = _cells[position.x, position.y];

            if (item == null)
            {
                throw new NullReferenceException();
            }

            return item;
        }

        public Item GetItem(in int x, in int y)
        {
            return GetItem(new Vector2Int(x, y));
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            if (IsPositionInBounds(position) == false)
            {
                item = null;
            }
            else
            {
                item = _cells[position.x, position.y];
            }

            return item != null;
        }

        public bool TryGetItem(in int x, in int y, out Item item)
        {
            return TryGetItem(new Vector2Int(x, y), out item);
        }

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
        {
            if (item == null)
            {
                throw new NullReferenceException("Trying to get positions on null item!");
            }

            if (Contains(item) == false)
            {
                throw new KeyNotFoundException();
            }

            return GetPositionsAt(_cachedItems[item], item.Size).ToArray();
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            positions = null;

            if (item == null || Contains(item) == false)
            {
                return false;
            }

            if (_cachedItems.TryGetValue(item, out var position))
            {
                positions = GetPositionsAt(position, item.Size).ToArray();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            _cachedItems.Clear();
            Array.Clear(_cells, 0, _cells.Length);
            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            return _cachedItems.Keys.Count(it => it.Name == name);
        }

        /// <summary>
        /// Moves a specified item to a target position if it exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int newPosition)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Can't move null item!");
            }

            if (Contains(item) == false
                || IsAreaInBounds(newPosition, item.Size) == false)
            {
                return false;
            }

            var newPositions = GetPositionsAt(newPosition, item.Size);

            foreach (var checkingPosition in newPositions)
            {
                if (TryGetItem(checkingPosition, out var itemAtPosition))
                {
                    if (item != itemAtPosition)
                    {
                        return false;
                    }
                }
            }

            foreach (var checkingPosition in GetPositions(item))
            {
                _cells[checkingPosition.x, checkingPosition.y] = null;
            }

            foreach (var checkingPosition in newPositions)
            {
                _cells[checkingPosition.x, checkingPosition.y] = item;
            }

            _cachedItems[item] = newPosition;

            OnMoved?.Invoke(item, newPosition);
            return true;
        }

        /// <summary>
        /// Reorganizes inventory space to make the free area uniform
        /// </summary>
        public void ReorganizeSpace()
        {
            var items = _cachedItems.Keys
                .OrderByDescending(it => it.Size.x * it.Size.y)
                .ToArray();

            Array.Clear(_cells, 0, _cells.Length);

            foreach (var item in items)
            {
                if (FindFreePosition(item.Size, out var position))
                {
                    foreach (var checkingPosition in GetPositionsAt(position, item.Size))
                    {
                        _cells[checkingPosition.x, checkingPosition.y] = item;
                    }
                    
                    _cachedItems[item] = position;
                }
                else
                {
                    throw new InvalidOperationException("Can't find free space for item while reorganizing!");
                }
            }
        }

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
        {
            Array.Copy(_cells, matrix, _cells.Length);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _cachedItems.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cachedItems.Keys.GetEnumerator();
        }

        private bool IsValidSize(Vector2Int size)
        {
            return size.x > 0
                   && size.y > 0;
        }

        private bool IsSizeFitsInInventory(Vector2Int size)
        {
            return size.x <= Width
                   && size.y <= Height;
        }

        private bool IsPositionInBounds(Vector2Int position)
        {
            return position.x >= 0
                   && position.x < Width
                   && position.y >= 0
                   && position.y < Height;
        }

        private bool IsAreaInBounds(Vector2Int position, Vector2Int size)
        {
            var sizedPivot = position + size - Vector2Int.one;
            return IsPositionInBounds(position) && IsPositionInBounds(sizedPivot);
        }

        private bool IsAreaFree(Vector2Int position, Vector2Int size)
        {
            return GetPositionsAt(position, size)
                .All(pos => IsFree(pos));
        }

        private IEnumerable<Vector2Int> GetPositionsAt(Vector2Int position, Vector2Int size)
        {
            for (var x = 0; x < size.x; x++)
            for (var y = 0; y < size.y; y++)
            {
                var checkingPosition = position + new Vector2Int(x, y);
                yield return checkingPosition;
            }
        }
    }
}