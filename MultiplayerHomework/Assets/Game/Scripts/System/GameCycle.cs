using System;
using Fusion;

namespace Game
{
    public sealed class GameCycle : NetworkBehaviour
    {
        public event Action<State> OnStateChanged;

        [Networked, OnChangedRender(nameof(InvokeStateChanged))]
        public State CurrentState { get; set; }

        private void InvokeStateChanged()
        {
            OnStateChanged?.Invoke(CurrentState);
        }

        public enum State
        {
            Running,
            Lose,
            Win
        }
    }
}