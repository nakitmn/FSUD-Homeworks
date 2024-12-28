using System;
using Modules;

namespace Level_Module
{
    public sealed class LevelManager
    {
        public event Action<bool> OnGameOver;
        public event Action OnLevelChanged
        {
            add => _difficulty.OnStateChanged += value;
            remove => _difficulty.OnStateChanged -= value;
        }
        
        private readonly IDifficulty _difficulty;

        public int CurrentLevel => _difficulty.Current;
        public int MaxLevel => _difficulty.Max;
        public bool IsRunning { get; private set; }

        public LevelManager(IDifficulty difficulty)
        {
            _difficulty = difficulty;
        }

        public void StartGame()
        {
            IsRunning = true;
            LevelUp();
        }

        public void LevelUp()
        {
            if (_difficulty.Next(out _) == false)
            {
                WinGame();
            }
        }

        public void WinGame()
        {
            IsRunning = false;
            OnGameOver?.Invoke(true);
        }

        public void LoseGame()
        {
            IsRunning = false;
            OnGameOver?.Invoke(false);
        }
    }
}