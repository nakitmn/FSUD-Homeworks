using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Level_Module
{
    public sealed class LoseGameController : IInitializable, ITickable, IDisposable
    {
        private readonly LevelManager _levelManager;
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        public LoseGameController(LevelManager levelManager, ISnake snake, IWorldBounds worldBounds)
        {
            _levelManager = levelManager;
            _snake = snake;
            _worldBounds = worldBounds;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += _levelManager.LoseGame;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= _levelManager.LoseGame;
        }

        void ITickable.Tick()
        {
            if (_levelManager.IsRunning == false)
            {
                return;
            }

            CheckSnakeInBounds();
        }

        private void CheckSnakeInBounds()
        {
            if (_worldBounds.IsInBounds(_snake.HeadPosition) == false)
            {
                _levelManager.LoseGame();
            }
        }
    }
}