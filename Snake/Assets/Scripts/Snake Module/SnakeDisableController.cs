using System;
using Level_Module;
using Modules;
using Zenject;

namespace Snake_Module
{
    public sealed class SnakeDisableController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly LevelManager _levelManager;

        public SnakeDisableController(ISnake snake, LevelManager levelManager)
        {
            _snake = snake;
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            _levelManager.OnGameOver += OnGameOver;
        }

        void IDisposable.Dispose()
        {
            _levelManager.OnGameOver -= OnGameOver;
        }

        private void OnGameOver(bool obj)
        {
            _snake.SetActive(false);
        }
    }
}