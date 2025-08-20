using System;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public sealed class GameBoardView : MonoBehaviour
    {
        [SerializeField] private GameBoardCellView _cellPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private float _cellOffset;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _highlightMaterial;

        private GameBoardCellView[,] _views;

        public void Create(int width, int height)
        {
            _views = new GameBoardCellView[width,height];

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
            {
                var spawnPosition = ToWorldPosition(x, y);
                var index = GetCellIndex(width, x, y);

                var view = Instantiate(_cellPrefab, spawnPosition, Quaternion.identity, _container);

                _views[x, y] = view;
                view.gameObject.name = $"Cell[{index}]";
                view.SetMaterial(_defaultMaterial);
            }
        }
        
        public GameBoardCellView GetViewAt(GameBoardPosition position)
        {
            return _views[position.x, position.y];
        }

        public Vector3 ToWorldPosition(GameBoardPosition position)
        {
            return ToWorldPosition(position.x, position.y);
        }

        public Vector3 ToWorldPosition(int x, int y)
        {
            var offset = new Vector3(x * _cellOffset, 0f, y * _cellOffset * -1f);
            return transform.position + offset;
        }

        public GameBoardPosition GetBoardPosition(GameBoardCellView view)
        {
            for (var x = 0; x < _views.GetLength(0); x++)
            for (var y = 0; y < _views.GetLength(1); y++)
            {
                if (_views[x, y] == view)
                {
                    return new GameBoardPosition(x, y);
                }
            }

            return GameBoardPosition.Invalid;
        }

        public void ClearMaterials()
        {
            for (var x = 0; x < _views.GetLength(0); x++)
            for (var y = 0; y < _views.GetLength(1); y++)
            {
                _views[x, y].SetMaterial(_defaultMaterial);
            }
        }

        public void HighlightCells(GameBoardPosition[] positions)
        {
            for (var x = 0; x < _views.GetLength(0); x++)
            for (var y = 0; y < _views.GetLength(1); y++)
            {
                if (Array.Exists(positions, p => p.x == x && p.y == y))
                {
                    _views[x, y].SetMaterial(_highlightMaterial);
                }
            }
        }
        
        public void ResetMoveEnabled()
        {
            for (var x = 0; x < _views.GetLength(0); x++)
            for (var y = 0; y < _views.GetLength(1); y++)
            {
                _views[x, y].PlayMoveDisabled();
            }
        }

        public void SetMoveEnabled(IEnumerable<GameBoardPosition> positions)
        {
            foreach (var position in positions)
            {
                _views[position.x, position.y].PlayMoveEnabled();
            }
        }

        private int GetCellIndex(int boardWidth, int x, int y)
        {
            return boardWidth * x + y;
        }
    }
}