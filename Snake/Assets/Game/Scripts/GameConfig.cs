using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Game", order = 0)]
    public sealed class GameConfig : ScriptableObject
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private int _levelsCount = 9;
        [SerializeField] private float _difficultySnakeSpeedRatio = 1f;

        public GameObject CoinPrefab => _coinPrefab;
        public int LevelsCount => _levelsCount;

        public float GetSpeedForLevel(int level)
        {
            return level * _difficultySnakeSpeedRatio;
        }
    }
}