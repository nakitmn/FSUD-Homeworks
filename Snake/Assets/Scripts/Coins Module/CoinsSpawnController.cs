using System;
using Coins_Module;
using Modules;
using Zenject;

namespace Level_Module
{
    public sealed class CoinsSpawnController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinsManager _coinsManager;

        public CoinsSpawnController(IDifficulty difficulty, CoinsManager coinsManager)
        {
            _difficulty = difficulty;
            _coinsManager = coinsManager;
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
            _coinsManager.SpawnCoins(_difficulty.Current);
        }
    }
}