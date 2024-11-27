using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Level_Module
{
    public sealed class GameOverController : IInitializable, ITickable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IGameUI _gameUI;
        private readonly IWorldBounds _worldBounds;
        private readonly LevelManager _levelManager;

        private bool _isEnabled = false;

        public GameOverController(
            ISnake snake,
            IGameUI gameUI,
            IWorldBounds worldBounds,
            LevelManager levelManager
        )
        {
            _snake = snake;
            _gameUI = gameUI;
            _worldBounds = worldBounds;
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += LoseGame;
            _levelManager.OnAllLevelsCompleted += OnAllLevelsCompleted;
            _isEnabled = true;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= LoseGame;
            _levelManager.OnAllLevelsCompleted -= OnAllLevelsCompleted;
        }

        void ITickable.Tick()
        {
            if (_isEnabled == false)
            {
                return;
            }

            if (_worldBounds.IsInBounds(_snake.HeadPosition) == false)
            {
                LoseGame();
            }
        }

        private void WinGame()
        {
            _snake.SetActive(false);
            _gameUI.GameOver(true);
            _isEnabled = false;
        }

        private void LoseGame()
        {
            _snake.SetActive(false);
            _gameUI.GameOver(false);
            _isEnabled = false;
        }

        private void OnAllLevelsCompleted()
        {
            WinGame();
        }
    }
}