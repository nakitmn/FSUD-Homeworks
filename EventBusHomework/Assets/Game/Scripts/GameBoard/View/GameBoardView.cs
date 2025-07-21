using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardView : MonoBehaviour
    {
        [SerializeField] private GameEntity _cellPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private float _cellOffset;
        [SerializeField] private Material[] _cellMaterials;

        private GameContext _gameContext;

        private void Awake()
        {
            _gameContext = GameContext.Instance;
        }

        private void Start()
        {
            var gameBoard = _gameContext.GetGameBoard();
            
            for (var x = 0; x < gameBoard.Width; x++)
            for (var y = 0; y < gameBoard.Height; y++)
            {
                var spawnPosition = ToWorldPosition(x, y);
                var cell = (GameEntity) GameEntity.Create(_cellPrefab, spawnPosition, Quaternion.identity, _container);
                var index = gameBoard.Width * x + y;
                cell.GetGameObject().name = $"Cell[{index}]";
                var materialOffset = (int) Mathf.Repeat(x, 2);
                var materialIndex = (int) Mathf.Repeat(index + materialOffset, _cellMaterials.Length);
                var material = _cellMaterials[materialIndex];
                cell.GetDefaultMaterial().Value = material;
                cell.GetCurrentMaterial().Value = material;
                cell.GetBoardPosition().Value = new(x, y);
            }
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
    }
}