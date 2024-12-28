using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Coins_Module
{
    public sealed class CoinCollectController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinsManager _coinsManager;

        public CoinCollectController(ISnake snake, CoinsManager coinsManager)
        {
            _snake = snake;
            _coinsManager = coinsManager;
        }

        void IInitializable.Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
        }

        void IDisposable.Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            _coinsManager.TryCollectCoin(position);
        }
    }
}