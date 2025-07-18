using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardView : MonoBehaviour
    {
        [SerializeField] private GameBoardCellView _cellPrefab;
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
                var offset = new Vector3(x * _cellOffset, 0f, y * _cellOffset * -1);
                var spawnPosition = transform.position + offset;
                var cellView = Instantiate(_cellPrefab, spawnPosition, Quaternion.identity, _container);
                var index = gameBoard.Width * x + y;
                cellView.gameObject.name = $"Cell[{index}]";
                var materialOffset = (int) Mathf.Repeat(x, 2);
                var materialIndex = (int) Mathf.Repeat(index + materialOffset, _cellMaterials.Length);
                var material = _cellMaterials[materialIndex];
                cellView.SetMaterial(material);
            }
        }
    }
}