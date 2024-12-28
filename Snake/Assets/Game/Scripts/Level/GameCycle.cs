using System;

namespace Level_Module
{
    public sealed class GameCycle
    {
        public event Action<bool> OnGameOver;

        public bool IsRunning { get; private set; }

        public void StartGame()
        {
            IsRunning = true;
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