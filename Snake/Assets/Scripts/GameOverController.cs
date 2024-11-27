using System;
using Modules;
using SnakeGame;
using Zenject;

namespace DefaultNamespace
{
    public sealed class GameOverController : IInitializable,ITickable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IGameUI _gameUI;
        private readonly IWorldBounds _worldBounds;

        private bool _isEnabled = false;
        
        public GameOverController(ISnake snake,IGameUI gameUI, IWorldBounds worldBounds)
        {
            _snake = snake;
            _gameUI = gameUI;
            _worldBounds = worldBounds;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += LoseGame;
            _isEnabled = true;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= LoseGame;
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

        private void LoseGame()
        {
            _snake.SetActive(false);
            _gameUI.GameOver(false);
            _isEnabled = false;
        }
    }
}