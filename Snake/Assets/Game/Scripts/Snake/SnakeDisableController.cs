using System;
using Level_Module;
using Modules;
using Zenject;

namespace Snake_Module
{
    public sealed class SnakeDisableController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly GameCycle _gameCycle;

        public SnakeDisableController(ISnake snake, GameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }

        void IInitializable.Initialize()
        {
            _gameCycle.OnGameOver += OnGameOver;
        }

        void IDisposable.Dispose()
        {
            _gameCycle.OnGameOver -= OnGameOver;
        }

        private void OnGameOver(bool obj)
        {
            _snake.SetActive(false);
        }
    }
}