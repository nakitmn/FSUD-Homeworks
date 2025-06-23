using System;
using Zenject;

namespace Game
{
    public sealed class LosePopupShowController : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly LosePopupPresenter _losePopupPresenter;

        public LosePopupShowController(GameCycle gameCycle, LosePopupPresenter losePopupPresenter)
        {
            _losePopupPresenter = losePopupPresenter;
            _gameCycle = gameCycle;
        }
        
        public void Initialize()
        {
            _gameCycle.OnStateChanged += OnStateChanged;
        }

        public void Dispose()
        {
            _gameCycle.OnStateChanged -= OnStateChanged;
        }

        private void OnStateChanged(GameCycle.State state)
        {
            if (state == GameCycle.State.Lose)
            {
                _losePopupPresenter.Enable();
            }
        }
    }
}