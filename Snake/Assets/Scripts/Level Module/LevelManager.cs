using System;
using Coins_Module;
using DefaultNamespace;
using Modules;
using SnakeGame;
using Zenject;

namespace Level_Module
{
    public sealed class LevelManager : IInitializable, ITickable, IDisposable
    {
        public event Action<bool> OnGameOver;

        private readonly GameConfig _gameConfig;
        private readonly CoinsManager _coinsManager;
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        private bool _isRunning;

        public LevelManager(
            GameConfig gameConfig,
            CoinsManager coinsManager,
            IDifficulty difficulty,
            ISnake snake,
            IWorldBounds worldBounds
        )
        {
            _gameConfig = gameConfig;
            _coinsManager = coinsManager;
            _difficulty = difficulty;
            _snake = snake;
            _worldBounds = worldBounds;
        }

        void IInitializable.Initialize()
        {
            _coinsManager.OnAllCoinsCollected += LevelUp;
            _snake.OnSelfCollided += LoseGame;

            LevelUp();
            _isRunning = true;
        }

        void IDisposable.Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= LevelUp;
            _snake.OnSelfCollided -= LoseGame;
        }

        void ITickable.Tick()
        {
            if (_isRunning == false)
            {
                return;
            }

            CheckSnakeInBounds();
        }

        private void CheckSnakeInBounds()
        {
            if (_worldBounds.IsInBounds(_snake.HeadPosition) == false)
            {
                LoseGame();
            }
        }

        private void LevelUp()
        {
            if (_difficulty.Next(out var nextDifficulty))
            {
                _coinsManager.SpawnCoins(nextDifficulty);
                _snake.SetSpeed(_gameConfig.GetSpeedForLevel(nextDifficulty));
            }
            else
            {
                WinGame();
            }
        }

        private void WinGame()
        {
            DisableGameplay();
            OnGameOver?.Invoke(true);
        }

        private void LoseGame()
        {
            DisableGameplay();
            OnGameOver?.Invoke(false);
        }

        private void DisableGameplay()
        {
            _snake.SetActive(false);
            _isRunning = false;
        }
    }
}