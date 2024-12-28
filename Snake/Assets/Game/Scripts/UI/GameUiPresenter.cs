using System;
using Game.Gameplay;
using Modules;
using SnakeGame;
using Zenject;

namespace Game.UI
{
    public sealed class GameUiPresenter : IInitializable, IDisposable
    {
        private readonly GameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public GameUiPresenter(GameCycle gameCycle, IDifficulty difficulty, IScore score, IGameUI gameUI)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _score = score;
            _gameUI = gameUI;
        }

        void IInitializable.Initialize()
        {
            _gameCycle.OnGameOver += _gameUI.GameOver;
            _difficulty.OnStateChanged += OnLevelChanged;
            _score.OnStateChanged += OnScoreChanged;

            OnLevelChanged();
            OnScoreChanged(_score.Current);
        }

        void IDisposable.Dispose()
        {
            _gameCycle.OnGameOver -= _gameUI.GameOver;
            _difficulty.OnStateChanged -= OnLevelChanged;
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnLevelChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}