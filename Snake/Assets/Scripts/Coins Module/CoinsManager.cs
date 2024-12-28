using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;

namespace Coins_Module
{
    public sealed class CoinsManager
    {
        public event Action OnAllCoinsCollected;

        private readonly IWorldBounds _worldBounds;
        private readonly ISnake _snake;
        private readonly ICoinsPool _coinsPool;
        private readonly ICoinCollectedListener[] _coinCollectedHandlers;

        private readonly Dictionary<Vector2Int, ICoin> _spawnedCoins = new();

        public CoinsManager(
            IWorldBounds worldBounds,
            ISnake snake,
            ICoinsPool coinsPool,
            ICoinCollectedListener[] coinCollectedHandlers
        )
        {
            _worldBounds = worldBounds;
            _snake = snake;
            _coinsPool = coinsPool;
            _coinCollectedHandlers = coinCollectedHandlers;
        }

        public void SpawnCoins(int count)
        {
            for (var i = 0; i < count; i++)
            {
                SpawnSingle();
            }
        }

        public void TryCollect(Vector2Int coinPosition)
        {
            if (_spawnedCoins.Remove(coinPosition, out var coin) == false)
            {
                return;
            }

            ApplyCoin(coin);

            if (_spawnedCoins.Count == 0)
            {
                OnAllCoinsCollected?.Invoke();
            }
        }

        private void SpawnSingle()
        {
            var position = Vector2Int.zero;

            do
            {
                position = _worldBounds.GetRandomPosition();
            } while (_snake.HeadPosition == position || _spawnedCoins.ContainsKey(position));

            var coin = _coinsPool.Spawn();
            coin.Position = position;

            _spawnedCoins.Add(position, coin);
        }

        private void ApplyCoin(ICoin coin)
        {
            Array.ForEach(_coinCollectedHandlers, it => it.OnCollected(coin));
            _coinsPool.Despawn(coin);
        }
    }
}