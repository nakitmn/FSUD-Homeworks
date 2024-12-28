using System;
using Coins_Module;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Level_Module
{
    public sealed class CoinsSpawnController : IInitializable, IDisposable
    {
        private readonly CoinsManager _coinsManager;
        private readonly LevelManager _levelManager;
        private readonly ISnake _snake;
        private readonly IWorldBounds _worldBounds;

        public CoinsSpawnController(CoinsManager coinsManager, LevelManager levelManager, ISnake snake,
            IWorldBounds worldBounds)
        {
            _snake = snake;
            _worldBounds = worldBounds;
            _coinsManager = coinsManager;
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            _levelManager.OnLevelChanged += OnLevelChanged;
        }

        void IDisposable.Dispose()
        {
            _levelManager.OnLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged()
        {
            for (var i = 0; i < _levelManager.CurrentLevel; i++)
            {
                SpawnCoin();
            }
        }

        private void SpawnCoin()
        {
            var position = Vector2Int.zero;

            do
            {
                position = _worldBounds.GetRandomPosition();
            } while (_snake.HeadPosition == position || _coinsManager.HasCoinAt(position));

            _coinsManager.TrySpawnCoin(position);
        }
    }
}