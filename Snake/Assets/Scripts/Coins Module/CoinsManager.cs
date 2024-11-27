using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Coins_Module
{
    public sealed class CoinsManager : IInitializable, IDisposable
    {
        public event Action OnAllCoinsCollected;

        private readonly IWorldBounds _worldBounds;
        private readonly ISnake _snake;
        private readonly ICoinsPool _coinsPool;
        private readonly IScore _score;

        private readonly Dictionary<Vector2Int, ICoin> _spawnedCoins = new();

        public CoinsManager(
            IWorldBounds worldBounds,
            ISnake snake,
            ICoinsPool coinsPool,
            IScore score
        )
        {
            _worldBounds = worldBounds;
            _snake = snake;
            _coinsPool = coinsPool;
            _score = score;
        }

        void IInitializable.Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
        }

        void IDisposable.Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        public void SpawnCoins(int count)
        {
            for (var i = 0; i < count; i++)
            {
                SpawnSingle();
            }
        }

        private void SpawnSingle()
        {
            Vector2Int position = Vector2Int.zero;

            do
            {
                position = _worldBounds.GetRandomPosition();
            } while (_snake.HeadPosition == position || _spawnedCoins.ContainsKey(position));

            var coin = _coinsPool.Spawn();
            coin.Position = position;

            _spawnedCoins.Add(position, coin);
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if (_spawnedCoins.Remove(position, out var coin))
            {
                ApplyCoin(coin);

                if (_spawnedCoins.Count == 0)
                {
                    OnAllCoinsCollected?.Invoke();
                }
            }
        }

        private void ApplyCoin(ICoin coin)
        {
            _snake.Expand(coin.Bones);
            _score.Add(coin.Score);
                
            _coinsPool.Despawn(coin);
        }
    }
}