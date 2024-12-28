using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;

namespace Coins_Module
{
    public sealed class CoinsManager
    {
        public event Action OnAllCoinsCollected;

        private readonly ICoinsPool _coinsPool;
        private readonly ICoinCollectedListener[] _coinCollectedHandlers;
        private readonly Dictionary<Vector2Int, ICoin> _spawnedCoins = new();

        public CoinsManager(ICoinsPool coinsPool, ICoinCollectedListener[] coinCollectedHandlers)
        {
            _coinsPool = coinsPool;
            _coinCollectedHandlers = coinCollectedHandlers;
        }

        public void TryCollectCoin(Vector2Int coinPosition)
        {
            if (_spawnedCoins.Remove(coinPosition, out var coin) == false)
            {
                return;
            }

            Array.ForEach(_coinCollectedHandlers, it => it.OnCollected(coin));
            _coinsPool.Despawn(coin);

            if (_spawnedCoins.Count == 0)
            {
                OnAllCoinsCollected?.Invoke();
            }
        }

        public bool TrySpawnCoin(Vector2Int position)
        {
            if (HasCoinAt(position))
            {
                return false;
            }

            var coin = _coinsPool.Spawn();
            coin.Position = position;

            _spawnedCoins.Add(position, coin);
            return true;
        }

        public bool HasCoinAt(Vector2Int position)
        {
            return _spawnedCoins.ContainsKey(position);
        }
    }
}