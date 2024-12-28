using System;
using Modules;
using Zenject;

namespace Game.Gameplay
{
    public sealed class LevelUpController : IInitializable, IDisposable
    {
        private readonly CoinsManager _coinsManager;
        private readonly IDifficulty _difficulty;
        private readonly GameCycle _gameCycle;

        public LevelUpController(CoinsManager coinsManager, IDifficulty difficulty, GameCycle gameCycle)
        {
            _coinsManager = coinsManager;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }
        
        void IInitializable.Initialize()
        {
            _coinsManager.OnAllCoinsCollected += OnAllCoinsCollected;
        }

        void IDisposable.Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= OnAllCoinsCollected;
        }
        
        private void OnAllCoinsCollected()
        {
            if (_difficulty.Next(out _) == false)
            {
                _gameCycle.WinGame();
            }
        }
    }
}