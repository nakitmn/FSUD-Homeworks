using System;
using Modules;
using Zenject;

namespace Level_Module
{
    public sealed class LevelManager
    {
        public event Action<bool> OnGameOver;

        private readonly IDifficulty _difficulty;

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