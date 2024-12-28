using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Game.Gameplay
{
    public sealed class LoseGameController : IInitializable, ITickable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        public LoseGameController(GameCycle gameCycle, ISnake snake, IWorldBounds worldBounds)
        {
            _gameCycle = gameCycle;
            _snake = snake;
            _worldBounds = worldBounds;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += _gameCycle.LoseGame;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= _gameCycle.LoseGame;
        }

        void ITickable.Tick()
        {
            if (_gameCycle.IsRunning == false)
            {
                return;
            }

            CheckSnakeInBounds();
        }

        private void CheckSnakeInBounds()
        {
            if (_worldBounds.IsInBounds(_snake.HeadPosition) == false)
            {
                _gameCycle.LoseGame();
            }
        }
    }
}