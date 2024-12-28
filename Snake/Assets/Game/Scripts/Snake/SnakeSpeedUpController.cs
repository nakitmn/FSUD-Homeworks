using System;
using Modules;
using Zenject;

namespace Game.Gameplay
{
    public sealed class SnakeSpeedUpController : IInitializable, IDisposable
    {
        private readonly GameConfig _gameConfig;
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;

        public SnakeSpeedUpController(GameConfig gameConfig, IDifficulty difficulty, ISnake snake)
        {
            _gameConfig = gameConfig;
            _difficulty = difficulty;
            _snake = snake;
        }

        void IInitializable.Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        void IDisposable.Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            var speed = _gameConfig.GetSpeedForLevel(_difficulty.Current);
            _snake.SetSpeed(speed);
        }
    }
}