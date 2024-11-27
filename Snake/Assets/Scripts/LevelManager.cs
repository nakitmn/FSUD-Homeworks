using System;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public sealed class LevelManager : IInitializable, IDisposable
    {
        public event Action OnAllLevelsCompleted;

        private readonly CoinsManager _coinsManager;
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;

        public LevelManager(CoinsManager coinsManager, IDifficulty difficulty, ISnake snake)
        {
            _coinsManager = coinsManager;
            _difficulty = difficulty;
            _snake = snake;
        }

        void IInitializable.Initialize()
        {
            _coinsManager.OnAllCoinsCollected += OnAllCoinsCollected;
            OnAllCoinsCollected();
        }

        void IDisposable.Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= OnAllCoinsCollected;
        }

        private void OnAllCoinsCollected()
        {
            if (_difficulty.Next(out var nextDifficulty))
            {
                _coinsManager.SpawnCoins(nextDifficulty);
                _snake.SetSpeed(nextDifficulty);
            }
            else
            {
                OnAllLevelsCompleted?.Invoke();
            }
        }
    }
}