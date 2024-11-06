using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable NotResolvedInText

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width => _width;
        public int Height => _height;
        public int Count => _items.Count;

        private readonly int _width;
        private readonly int _height;
        private readonly Dictionary<Item, List<Vector2Int>> _items;

        public Inventory(in int width, in int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid inventory size!");
            }

            _width = width;
            _height = height;
            _items = new Dictionary<Item, List<Vector2Int>>();
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
            
            if (IsInBounds(position) == false)
            {
                return false;
            }
            
            if (item.Size.x <= 0 || item.Size.y <= 0)
            {
                throw new ArgumentException("Invalid item size!");
            }

            if (Contains(item))
            {
                return false;
            }

            var otherPivot = position + item.Size - Vector2Int.one;
            
            if (IsInBounds(otherPivot) == false)
            {
                return false;
            }

            for (var x = 0; x <= item.Size.x; x++)
            {
                for (var y = 0; y <= item.Size.y; y++)
                {
                    var checkingPosition = position + new Vector2Int(x, y);

                    if (IsFree(checkingPosition) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
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

            List<Vector2Int> positions = new List<Vector2Int>();

            for (var x = 0; x < item.Size.x; x++)
            {
                for (var y = 0; y < item.Size.y; y++)
                {
                    var checkingPosition = position + new Vector2Int(x, y);
                    positions.Add(checkingPosition);
                }
            }

            _items.Add(item, positions);
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
            => throw new NotImplementedException();

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
            => throw new NotImplementedException();

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
            => throw new NotImplementedException();

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            if (item == null)
            {
                return false;
            }

            return _items.ContainsKey(item);
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
            foreach (var (item, positions) in _items)
            {
                foreach (var checkingPosition in positions)
                {
                    if (checkingPosition == position)
                    {
                        return false;
                    }
                }
            }

            return true;
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
            if (item == null)
            {
                return false;
            }
            
            return _items.Remove(item);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            position = default;
            
            if (item == null)
            {
                return false;
            }
            
            if (_items.Remove(item, out var positions))
            {
                position = positions[0];
                OnRemoved?.Invoke(item, position);
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            if (IsInBounds(position) == false)
            {
                throw new IndexOutOfRangeException();
            }

            foreach (var (item, positions) in _items)
            {
                if (positions.Contains(position))
                {
                    return item;
                }
            }

            throw new NullReferenceException("Item not found!");
        }

        public Item GetItem(in int x, in int y)
        {
            return GetItem(new Vector2Int(x, y));
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            foreach (var (checkingItem, positions) in _items)
            {
                if (positions.Contains(position))
                {
                    item = checkingItem;
                    return true;
                }
            }

            item = null;
            return false;
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

            if (_items.TryGetValue(item, out var positionsList))
            {
                return positionsList.ToArray();
            }

            throw new KeyNotFoundException($"Inventory doesn't contain item with name {item.Name}!");
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            positions = null;

            if (item == null)
            {
                return false;
            }

            if (_items.TryGetValue(item, out var positionsList) == false)
            {
                return false;
            }

            positions = positionsList.ToArray();
            return true;
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

            _items.Clear();
            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            return _items.Count(it => it.Key.Name == name);
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

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reorganizes inventory space to make the free area uniform
        /// </summary>
        public void ReorganizeSpace()
            => throw new NotImplementedException();

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
        {
            foreach (var (item, positions) in _items)
            {
                foreach (var position in positions)
                {
                    matrix[position.y, position.x] = item;
                }
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }
        
        private bool IsInBounds(Vector2Int position)
        {
            return position.x >= 0
                   && position.x < _width
                   && position.y >= 0
                   && position.y < _height;
        }
    }
}