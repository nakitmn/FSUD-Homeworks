using System;
using Coins_Module;
using Zenject;

namespace Level_Module
{
    public sealed class LevelUpController : IInitializable, IDisposable
    {
        private readonly CoinsManager _coinsManager;
        private readonly LevelManager _levelManager;

        public LevelUpController(CoinsManager coinsManager, LevelManager levelManager)
        {
            _coinsManager = coinsManager;
            _levelManager = levelManager;
        }
        
        void IInitializable.Initialize()
        {
            _coinsManager.OnAllCoinsCollected += _levelManager.LevelUp;
        }
        
        void IDisposable.Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= _levelManager.LevelUp;
        }
    }
}