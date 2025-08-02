using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardPresenter : MonoBehaviour
    {
        [SerializeField] private GameBoardCellView _cellPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private float _cellOffset;
        [SerializeField] private Material[] _cellMaterials;

        private GameContext _gameContext;
        private GameBoardCellView[,] _views;

        public GameBoardCellView[,] Views => _views;

        private void Awake()
        {
            _gameContext = GameContext.Instance;

            var gameBoard = _gameContext.GetGameBoard();
            _views = new GameBoardCellView[gameBoard.Width, gameBoard.Height];

            for (var x = 0; x < gameBoard.Width; x++)
            for (var y = 0; y < gameBoard.Height; y++)
            {
                var spawnPosition = ToWorldPosition(x, y);
                var index = GetCellIndex(gameBoard.Width, x, y);
                var material = GetCellMaterialFor(index, x);

                var view = Instantiate(_cellPrefab, spawnPosition, Quaternion.identity, _container);

                _views[x, y] = view;
                view.gameObject.name = $"Cell[{index}]";
                view.SetMaterial(material);
            }
        }

        private int GetCellIndex(int boardWidth, int x, int y)
        {
            return boardWidth * x + y;
        }

        private Material GetCellMaterialFor(int index, int x)
        {
            var materialOffset = (int) Mathf.Repeat(x, 2);
            var materialIndex = (int) Mathf.Repeat(index + materialOffset, _cellMaterials.Length);
            return _cellMaterials[materialIndex];
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

        public void ClearMaterials()
        {
            for (var x = 0; x < _views.GetLength(0); x++)
            for (var y = 0; y < _views.GetLength(1); y++)
            {
                var index = GetCellIndex(_views.GetLength(0), x, y);
                var material = GetCellMaterialFor(index, x);
                _views[x, y].SetMaterial(material);
            }
        }
    }
}